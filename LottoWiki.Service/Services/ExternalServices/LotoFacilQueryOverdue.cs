using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryOverdue : ILotoFacilQueryOverdue
    {
        private readonly ILotoFacilRepositoryOverdue _repository;

        public LotoFacilQueryOverdue(ILotoFacilRepositoryOverdue repository)
        {
            _repository = repository;
        }

        public LotoFacilViewModelSmal GetById(int id)
        {
            int[] values = new int[25];
            var response = _repository.GetById(id);
            var small = new LotoFacilViewModelSmal();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(response));
                values[i] = ball;
            }

            small.Concurso = response.Concurso;
            small.Values = values;

            return small;
        }

        public LotoFacilViewModelSmal GetLast()
        {
            int[] values = new int[25];
            var response = _repository.GetLast();
            var small = new LotoFacilViewModelSmal();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(response));
                values[i] = ball;
            }

            small.Concurso = response.Concurso;
            small.Values = values;

            return small;
        }
    }
}