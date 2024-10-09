using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryStatus : ILotoFacilQueryStatus
    {
        private readonly ILotoFacilCommonRepositoryStatus _repository;

        public LotoFacilQueryStatus(ILotoFacilCommonRepositoryStatus repository)
        {
            _repository = repository;
        }

        public char[] GetLast()
        {
            char[] StatusValues = new char[25];
            LotoFacilStatus lastStatus = _repository.GetLast();

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilStatus).GetProperty(propertyName);
                StatusValues[i] = (char)(property.GetValue(lastStatus));
            }

            return StatusValues;
        }

        public int GetLastId()
        {
            var lastStatus = _repository.GetLast();
            int lastId = lastStatus.Concurso;
            return lastId;
        }

        public char[] GetById(int id)
        {
            char[] StatusValues = new char[25];
            var lastStatus = _repository.GetById(id);

            for (int i = 0; i < 25; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", i + 1);
                var property = typeof(LotoFacilStatus).GetProperty(propertyName);
                StatusValues[i] = (char)(property.GetValue(lastStatus));
            }

            return StatusValues;
        }
    }
}