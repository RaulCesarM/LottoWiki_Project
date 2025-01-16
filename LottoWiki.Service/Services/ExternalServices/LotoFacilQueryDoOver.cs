using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryDoOver : ILotoFacilQueryDoOver
    {
        private readonly ILotoFacilCommonRepositoryDoOver _repository;

        public LotoFacilQueryDoOver(ILotoFacilCommonRepositoryDoOver repository)
        {
            _repository = repository;
        }

        public int[] GetLast()
        {
            int[] values = new int[25];
            var lastDoOver = _repository.GetLast();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(lastDoOver));
                values[i] = ball;
            }

            return values;
        }
    }
}