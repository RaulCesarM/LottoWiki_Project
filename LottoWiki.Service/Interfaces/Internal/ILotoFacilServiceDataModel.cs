using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Interfaces.Internal
{
    public interface ILotoFacilServiceDataModel
    {
        Task<LotoFacilDataModelViewModel> GetById(int key);

        Task Insert(LotoFacilDataModelViewModel entity);

        LotoFacilDataModelViewModel GetLast();
    }
}