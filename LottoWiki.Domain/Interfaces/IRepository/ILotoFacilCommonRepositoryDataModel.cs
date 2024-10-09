using LottoWiki.Domain.Models.MachineLearning;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilCommonRepositoryDataModel
    {
        Task<LotoFacilDataModel> GetById(int id);

        Task Insert(LotoFacilDataModel entity);

        LotoFacilDataModel GetLast();
    }
}