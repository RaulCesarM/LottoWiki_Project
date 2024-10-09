using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryOcurrences : ILotoFacilQueryOcurrences
    {
        private readonly ILotoFacilCommonRepository _repository;

        public LotoFacilQueryOcurrences(ILotoFacilCommonRepository repository)
        {
            _repository = repository;
        }

        public int[] GetLast()
        {
            int[] occurrencesValues = new int[25];
            List<LotoFacil> lotoFacils = _repository.GetInRangeAsync(100).Result;

            foreach (var lotoFacil in lotoFacils)
            {
                for (int j = 1; j <= 15; j++)
                {
                    string propertyName = BallNameFormatter.FormatBallName("Casa", j);
                    var property = typeof(LotoFacil).GetProperty(propertyName);
                    int ball = (int)property.GetValue(lotoFacil);

                    if (ball >= 1 && ball <= 25)
                    {
                        occurrencesValues[ball - 1]++;
                    }
                }
            }

            return occurrencesValues;
        }
    }
}