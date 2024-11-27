using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilCommonRepositoryDoOver : IBaseRepository<LotoFacilDoOver>
    {
        Task<List<LotoFacilDoOver>> GetEntityList(int id);

        Task<List<LotoFacilDoOver>> GetEntityListInRange(int id, int range);
    }
}