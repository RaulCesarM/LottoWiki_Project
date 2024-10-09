using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Interfaces.MachineLearning.Training
{
    public interface ILotoFacilSdcaMaximumEntropy
    {
        Task<TrainingResult> TrainingSequences();

        Task<string> PredictSequences(string sequence);

        Task<TrainingResult> TrainingLetter();

        Task<string> PredictLetter(string sequence);
    }
}