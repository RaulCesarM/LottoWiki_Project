﻿using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.Logging;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.LotoFacilSupply
{
    public class LotoFacilSupplyOverdue : ILotoFacilSupplyOverdue
    {
        private readonly ILotoFacilService _baseService;
        private readonly ILotoFacilServiceOverdue _overdueService;
        private int NextOverdueId { get; set; }
        private int CurrentBaseId { get; set; }
        public LotoFacilViewModelOverdue LastOverDue { get; set; }
        public LotoFacilViewModel LastBase { get; set; }
        public LotoFacilViewModelOverdue NewOverDue { get; set; } = new();
        public List<int> CalculatedBalls { get; set; } = [];
        private readonly ILogger<LotoFacilSupplyOverdue> _logger;

        public LotoFacilSupplyOverdue(ILotoFacilService services,
                                      ILotoFacilServiceOverdue overdueServices,
                                      ILogger<LotoFacilSupplyOverdue> logger)
        {
            _baseService = services;
            _overdueService = overdueServices;
            _logger = logger;
        }

        public bool HasNext()
        {
            _logger.LogMethodInfo();
            NextOverdueId = _overdueService.GetNextId();
            if (!_baseService.Exists(NextOverdueId)) return false;
            Init();
            return true;
        }

        public void Init()
        {
            LastOverDue = _overdueService.GetLast();
            LastBase = _baseService.GetById(NextOverdueId);
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
                int ball = Convert.ToInt32(property.GetValue(LastOverDue));
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
                property.SetValue(NewOverDue, CalculatedBalls[i]);
            }
            NewOverDue.Concurso = LastBase.Concurso;
            NewOverDue.ProximoConcurso = LastBase.ProximoConcurso;
            NewOverDue.ConcursoAnterior = LastBase.ConcursoAnterior;
        }

        private async Task Save()
        {
            try
            {
                await _overdueService.Insert(NewOverDue);
            }
            catch (Exception ex)
            {
                var msg = $"OverDue não foi persistida / causa {ex.Message}";
                _logger.LogMethodInfo(msg);
            }
        }
    }
}