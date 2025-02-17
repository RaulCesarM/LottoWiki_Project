using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.Logging;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.SupplyServices
{
    public class LotoFacilSupplyDoOver : ILotoFacilSupplyDoOver
    {
        private readonly ILogger<LotoFacilSupplyDoOver> _logger;
        private readonly ILotoFacilServiceDoOver _dooverService;
        private readonly ILotoFacilServiceOverdue _overdueService;

        private int NextDoOverId { get; set; }
        private int CurrentBaseId { get; set; }

        public LotoFacilViewModelOverdue LastOverDue { get; set; }
        public LotoFacilViewModelDoOver LastDoOver { get; set; }
        public LotoFacilViewModelDoOver NewDoOver { get; set; } = new();

        public List<int> OverdueCountage { get; set; } = [];
        public List<int> DoOverCountage { get; set; } = [];

        public LotoFacilSupplyDoOver(ILotoFacilServiceDoOver dooverService,
                                     ILotoFacilServiceOverdue overdueService,
                                     ILogger<LotoFacilSupplyDoOver> logger)
        {
            _dooverService = dooverService;
            _overdueService = overdueService;
            _logger = logger;
        }

        public bool HasNext()
        {
            _logger.LogMethodInfo();
            NextDoOverId = _dooverService.GetNextId();
            if (!_overdueService.Exists(NextDoOverId)) return false;
            Init();
            return true;
        }

        public void Init()
        {
            LastOverDue = _overdueService.GetById(NextDoOverId);
            LastDoOver = _dooverService.GetLast();
            PopulateLockyBalls();
            Populate();
            Save().Wait();
        }

        private void PopulateLockyBalls()
        {
            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(LastOverDue));
                OverdueCountage.Add(ball);
            }

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(LastDoOver));
                DoOverCountage.Add(ball);
            }

            for (int i = 0; i < 25; i++)
            {
                if (OverdueCountage[i] == 0)
                {
                    DoOverCountage[i] = DoOverCountage[i] + 1;
                }
                else
                {
                    DoOverCountage[i] = 0;
                }
            }
        }

        private void Populate()
        {
            _logger.LogMethodInfo();
            NewDoOver.Macro_Estado = 0;
            for (int i = 0; i < OverdueCountage.Count; i++)
            {
                NewDoOver.Macro_Estado += DoOverCountage[i];
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                property.SetValue(NewDoOver, DoOverCountage[i]);
            }
            NewDoOver.Concurso = LastOverDue.Concurso;
            NewDoOver.ProximoConcurso = LastOverDue.ProximoConcurso;
            NewDoOver.ConcursoAnterior = LastOverDue.ConcursoAnterior;
        }

        private async Task Save()
        {
            try
            {
                await _dooverService.Insert(NewDoOver);
            }
            catch (Exception ex)
            {
                var msg = $"OverDue não foi persistida / causa {ex.Message}";
                _logger.LogMethodInfo(msg);
            }
        }
    }
}