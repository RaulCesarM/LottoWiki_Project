using LottoWiki.Service.Interfaces.Base;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.Internal
{
    public interface ILotoFacilService : IBaseService<LotoFacilViewModel, int>
    {
        Task<int> CountOccurrencesInRangeAsync(int ball, int range);
    }
}