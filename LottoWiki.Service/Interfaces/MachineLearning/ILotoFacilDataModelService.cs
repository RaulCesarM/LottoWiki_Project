using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.MachineLearning
{
    public interface ILotoFacilDataModelService
    {
        public void CreateCsv(string filePath);
    }
}