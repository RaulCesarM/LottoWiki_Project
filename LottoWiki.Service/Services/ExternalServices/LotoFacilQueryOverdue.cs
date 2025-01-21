using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryOverdue : ILotoFacilQueryOverdue
    {
        private readonly ILotoFacilCommonRepositoryOverdue _repository;

        public LotoFacilQueryOverdue(ILotoFacilCommonRepositoryOverdue repository)
        {
            _repository = repository;
        }

        public LotoFacilOverDueSmalViewModel GetById(int id)
        {
            int[] OverdueValues = new int[25];
            var overdue = _repository.GetById(id);
            var overdueViewModel = new LotoFacilOverDueSmalViewModel();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(overdue));
                OverdueValues[i] = ball;
            }

            overdueViewModel.Concurso = overdue.Concurso;
            overdueViewModel.AtrasosOrdenado = OverdueValues;

            return overdueViewModel;
        }

        public LotoFacilOverDueSmalViewModel GetLast()
        {
            int[] OverdueValues = new int[25];
            var lastOverdue = _repository.GetLast();
            var overdueViewModel = new LotoFacilOverDueSmalViewModel();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(lastOverdue));
                OverdueValues[i] = ball;
            }

            overdueViewModel.Concurso = lastOverdue.Concurso;
            overdueViewModel.AtrasosOrdenado = OverdueValues;

            return overdueViewModel;
        }
    }
}