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
        private readonly ILotoFacilService _baseService;

        private int NextDoOverId { get; set; }
        private int CurrentBaseId { get; set; }

        public LotoFacilViewModelDoOver LastDoOver { get; set; }
        public LotoFacilViewModel LastBase { get; set; }
        public LotoFacilViewModelDoOver NewDoOver { get; set; } = new();

        public List<int> CalculatedBalls { get; set; } = [];

        public LotoFacilSupplyDoOver(ILotoFacilService services,
                                     ILotoFacilServiceDoOver dooverService,
                                     ILogger<LotoFacilSupplyDoOver> logger)
        {
            _baseService = services;
            _dooverService = dooverService;
            _logger = logger;
        }

        public bool HasNext()
        {
            _logger.LogMethodInfo();
            NextDoOverId = _dooverService.GetNextId();
            if (!_baseService.Exists(NextDoOverId)) return false;
            Init();
            return true;
        }

        public void Init()
        {
            LastDoOver = _dooverService.GetLast();
            LastBase = _baseService.GetById(NextDoOverId);
            PopulateLockyBalls();
            Populate();
            Save().Wait();
        }

        private void PopulateLockyBalls()
        {
            List<int> luckyBalls = new List<int>();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(LastDoOver));
                CalculatedBalls.Add(ball);
            }

            for (int i = 0; i < 15; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Casa", i + 1);
                var property = typeof(LotoFacilViewModel).GetProperty(propertyName);
                int luckyBall = Convert.ToInt32(property.GetValue(LastBase));
                luckyBalls.Add(luckyBall);
            }

            for (int i = 0; i < 25; i++)
            {
                CalculatedBalls[i] = luckyBalls.Contains(i + 1) ? 0 : CalculatedBalls[i] + 1;
            }
        }

        private void Populate()
        {
            _logger.LogMethodInfo();
            for (int i = 0; i < CalculatedBalls.Count; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilViewModelOverdue).GetProperty(propertyName);
                property.SetValue(NewDoOver, CalculatedBalls[i]);
            }
            NewDoOver.Concurso = LastBase.Concurso;
            NewDoOver.ProximoConcurso = LastBase.ProximoConcurso;
            NewDoOver.ConcursoAnterior = LastBase.ConcursoAnterior;
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