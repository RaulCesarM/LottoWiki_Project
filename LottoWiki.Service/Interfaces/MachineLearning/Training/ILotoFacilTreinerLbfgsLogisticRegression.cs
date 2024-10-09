using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Interfaces.MachineLearning.Training
{
    public interface ILotoFacilTreinerLbfgsLogisticRegression
    {
        Task<TrainingResult> Training();

        Task<string> LoadModelAndPredict(int id);
    }
}