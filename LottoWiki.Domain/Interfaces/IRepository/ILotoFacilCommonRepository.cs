using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilCommonRepository : IBaseRepository<LotoFacil>
    {
        Task<int> CountOccurrencesInRange(int ball, int range);

        Task<List<LotoFacil>> GetInRangeAsync(int range);
    }
}