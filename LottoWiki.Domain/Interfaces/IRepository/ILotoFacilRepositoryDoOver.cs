using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilRepositoryDoOver : IRepository<LotoFacilDoOver>
    {
        Task<List<LotoFacilDoOver>> GetEntityList(int id);

        Task<List<LotoFacilDoOver>> GetEntityListInRange(int id, int range);

        Task<List<int>> GetGlobalStandardDeviation();

        Task<List<int>> GetGlobalMeans();
    }
}