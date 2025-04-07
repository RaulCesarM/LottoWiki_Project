using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.Internal
{
    public interface ILotoFacilServiceDoOver : IService<LotoFacilViewModelDoOver, int>
    {
        double GetGlobalStandardDeviation();

        double GetGlobalMeans();
    }
}