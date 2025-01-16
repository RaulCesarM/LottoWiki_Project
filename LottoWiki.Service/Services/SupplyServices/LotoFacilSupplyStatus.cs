using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Interfaces.Supply;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;
using Microsoft.Extensions.Logging;

namespace LottoWiki.Service.Services.LotoFacilSupply
{
    public class LotoFacilSupplyStatus : ILotoFacilSupplyStatus
    {
        private readonly ILotoFacilServiceOverdue _baseServices;
        private readonly ILotoFacilServiceStatus _statusServices;
        private readonly ILogger<LotoFacilSupplyStatus> _logger;
        private readonly bool _hasCurrentBaseId;
        private readonly bool _hasNextBaseId;
        private readonly int _currentId;
        private readonly int _nextId;

        private LotoFacilViewModelStatus NextStatus { get; set; }
        private LotoFacilViewModelOverdue LastOverDue { get; set; }
        private LotoFacilViewModelOverdue CurrentOverDue { get; set; }

        public LotoFacilSupplyStatus(ILotoFacilServiceOverdue baseServices, ILotoFacilServiceStatus statusServices, ILogger<LotoFacilSupplyStatus> logger)
        {
            _baseServices = baseServices;
            _statusServices = statusServices;
            _nextId = statusServices.GetNextId();
            _currentId = statusServices.GetLastId();
            _hasNextBaseId = _baseServices.Exists(_nextId);
            _hasCurrentBaseId = _baseServices.Exists(_currentId);
            _logger = logger;
        }

        public bool HasNext()
        {
            if (_hasNextBaseId && _hasCurrentBaseId)
            {
                Init();
                Populate();
                Save().Wait();
                return true;
            }
            return false;
        }

        public void Init()
        {
            LastOverDue = _baseServices.GetById(_currentId);
            CurrentOverDue = _baseServices.GetById(_nextId);
        }

        public void Populate()
        {
            List<int> nextOverBalls = PopulateBallsStatus(CurrentOverDue);
            List<int> currentOverBalls = PopulateBallsStatus(LastOverDue);
            NextStatus = PopulateBalls(nextOverBalls, currentOverBalls);
            NextStatus.Concurso = CurrentOverDue.Concurso;
            NextStatus.ConcursoAnterior = CurrentOverDue.ConcursoAnterior;
            NextStatus.ProximoConcurso = CurrentOverDue.ProximoConcurso;
        }

        private static List<int> PopulateBallsStatus(LotoFacilViewModelOverdue overDue)
        {
            List<int> balls = [];
            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                int overDueBall = Convert.ToInt32(property.GetValue(overDue));
                balls.Add(overDueBall);
            }
            return balls;
        }

        private static LotoFacilViewModelStatus PopulateBalls(List<int> nextOverBalls, List<int> previusOverBalls)
        {
            LotoFacilViewModelStatus lotoFacilViewModelStatus = new();

            for (int i = 0; i < 25; i++)
            {
                int previus = previusOverBalls[i];
                int next = nextOverBalls[i];
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelStatus).GetProperty(propertyName);

                if (previus == 0 && next == 0)
                {
                    property.SetValue(lotoFacilViewModelStatus, 'R');
                }
                else if (previus < next)
                {
                    property.SetValue(lotoFacilViewModelStatus, 'A');
                }
                else if (previus > next)
                {
                    property.SetValue(lotoFacilViewModelStatus, 'N');
                }
            }
            return lotoFacilViewModelStatus;
        }

        private async Task Save()
        {
            try
            {
                await _statusServices.Insert(NextStatus);
            }
            catch (Exception ex)
            {
                var msg = $"Status não foi persistida / causa {ex.Message}";
                _logger.LogMethodInfo(msg);
            }
        }
    }
}