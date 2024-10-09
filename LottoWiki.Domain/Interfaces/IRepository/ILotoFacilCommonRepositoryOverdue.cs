using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilCommonRepositoryOverdue : IBaseRepository<LotoFacilOverdue>
    {
        Task<List<LotoFacilOverdue>> GetEntityList(int id);

        Task<List<LotoFacilOverdue>> GetEntityListInRange(int id, int range);
    }
}