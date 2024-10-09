using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryDataModel
    {
        Task<LotoFacilDataModelViewModel> CreateDataModel(int id, int ball);
    }
}