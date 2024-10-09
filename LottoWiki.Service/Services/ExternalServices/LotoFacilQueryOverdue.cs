using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryOverdue : ILotoFacilQueryOverdue
    {
        private readonly ILotoFacilCommonRepositoryOverdue _repository;

        public LotoFacilQueryOverdue(ILotoFacilCommonRepositoryOverdue repository)
        {
            _repository = repository;
        }

        public int[] GetLast()
        {
            int[] OverdueValues = new int[25];
            var lastOverDue = _repository.GetLast();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilOverdue).GetProperty(propertyName);
                int ball = Convert.ToInt32(property.GetValue(lastOverDue));
                OverdueValues[i] = ball;
            }

            return OverdueValues;
        }
    }
}