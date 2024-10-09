using LottoWiki.Service.Interfaces.MachineLearning.Training;
using LottoWiki.Service.ViewModels.MachineLearning;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace LottoWiki.Service.Services.MachineLearning.Training
{
    public class LbfgsMaximumEntropyLearning
    {
        private readonly string _modelPath;
        private readonly IDataConverter _data;

        public LbfgsMaximumEntropyLearning(IDataConverter data)
        {
            _data = data;
            _modelPath = Path.Combine("MachineLearning", "LbfgsMaximumEntropy.zip");

            if (!Directory.Exists(_modelPath))
            {
                Directory.CreateDirectory(_modelPath);
            }
        }

        public async Task<TrainingResult> Training()
        {
            var data = await _data.PopulateLbfgsMaximumEntropy();
            var mlContext = new MLContext();

            IDataView dataView = mlContext.Data.LoadFromEnumerable(data);

            var splitData = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var (sdcaModel, sdcaMetrics) = EstimatorTreinners.LbfgsMaximumEntropyEstimator(mlContext, splitData);

            TrainingResult result = CreateResult(sdcaMetrics);

            mlContext.Model.Save(sdcaModel, dataView.Schema, _modelPath);

            return result;
        }

        private TrainingResult CreateResult(MulticlassClassificationMetrics metrics)
        {
            return new TrainingResult
            {
                Success = true,
                Message = $"Modelo treinado com sucesso.\n" +
                         $"Acurácia Macro: {metrics.MacroAccuracy:P2}\n" +
                         $"Log-Loss: {metrics.LogLoss:F2}\n" +
                         $"Log-Loss por classe: {string.Join(", ", metrics.PerClassLogLoss.Select(c => c.ToString("F2")))}\n",
                ModelPath = _modelPath
            };
        }
    }
}