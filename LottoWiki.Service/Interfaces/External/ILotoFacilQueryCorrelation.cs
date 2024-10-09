using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryCorrelation
    {
        int[][] PopulateArrayOfArrays(int range);

        LotoFacilViewModelCorrelationPlaces GetTopCorrelationsForTarget(int targetNumber);
    }
}