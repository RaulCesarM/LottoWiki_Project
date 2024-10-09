using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Interfaces.MachineLearning.Training
{
    public interface IDataConverter
    {
        Task<List<LottoFacilLightGbm>> PopulateLightGbm();

        Task<List<LotoFacilLbfgsMaximumEntropy>> PopulateLbfgsMaximumEntropy();

        Task<List<LotoFacilLbfgsLogisticRegression>> PopulateLotoFacilLbfgsLogisticRegression();

        Task<int> CreateCSV();
    }
}