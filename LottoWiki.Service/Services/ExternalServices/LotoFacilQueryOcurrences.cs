using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryOcurrences : ILotoFacilQueryOcurrences
    {
        private readonly ILotoFacilRepository _repository;

        public LotoFacilQueryOcurrences(ILotoFacilRepository repository)
        {
            _repository = repository;
        }

        public LotoFacilViewModelSmal GetById(int id)
        {
            int[] values = new int[25];
            List<LotoFacil> response = _repository.GetInRangeFromConcursoAsync(id, 20).Result;
            var small = new LotoFacilViewModelSmal();

            foreach (var lotoFacil in response)
            {
                for (int j = 1; j <= 15; j++)
                {
                    string propertyName = BallNameFormatter.FormatBallName("Casa", j);
                    var property = typeof(LotoFacil).GetProperty(propertyName);
                    int ball = (int)property.GetValue(lotoFacil);

                    if (ball >= 1 && ball <= 25)
                    {
                        values[ball - 1]++;
                    }
                }
            }
            small.Concurso = response.LastOrDefault().Concurso;
            small.Values = values;
            return small;
        }

        public LotoFacilViewModelSmal GetLast()
        {
            int[] values = new int[25];
            List<LotoFacil> response = _repository.GetInRangeAsync(20).Result;
            var small = new LotoFacilViewModelSmal();

            foreach (var lotoFacil in response)
            {
                for (int j = 1; j <= 15; j++)
                {
                    string propertyName = BallNameFormatter.FormatBallName("Casa", j);
                    var property = typeof(LotoFacil).GetProperty(propertyName);
                    int ball = (int)property.GetValue(lotoFacil);

                    if (ball >= 1 && ball <= 25)
                    {
                        values[ball - 1]++;
                    }
                }
            }
            small.Concurso = response.LastOrDefault().Concurso;
            small.Values = values;
            return small;
        }
    }
}