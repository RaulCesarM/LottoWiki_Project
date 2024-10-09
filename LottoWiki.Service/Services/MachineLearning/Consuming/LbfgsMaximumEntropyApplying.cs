using LottoWiki.Service.ViewModels.MachineLearning;
using Microsoft.ML;
using System.Text;

namespace LottoWiki.Service.Services.MachineLearning.Consuming
{
    public class LbfgsMaximumEntropyApplying
    {
        private readonly string _modelFolder = Path.Combine("MachineLearning");

        private readonly string _modelPath;

        public LbfgsMaximumEntropyApplying()
        {
            _modelPath = Path.Combine(_modelFolder, "LbfgsMaximumEntropy.zip");
            if (!Directory.Exists(_modelFolder))
            {
                Directory.CreateDirectory(_modelFolder);
            }
        }

        public string PredictSequences(string mainSequence)
        {
            var mlContext = new MLContext();

            ITransformer trainedModel = mlContext.Model.Load(_modelPath, out DataViewSchema modelSchema);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<LotoFacilLbfgsMaximumEntropy, PredictionModel>(trainedModel);

            var input = new LotoFacilLbfgsMaximumEntropy
            {
                ThreeSequenceMainSequence = mainSequence
            };

            var prediction = predictionEngine.Predict(input);
            var retorno = new StringBuilder();

            retorno.AppendLine($"Predicted Next sequnce: {prediction.PredictedNextLetter}");

            if (prediction.Score != null && prediction.Score.Length > 0)
            {
                var classNames = new[]
                {
                   "AAA", "AAN", "AAR", "NAN",  "ANR", "NAR", "NAN",  "NRR", "NNR", "NRA", "RRR", "ARR"};

                retorno.AppendLine($"Predicted score: {prediction.Score.Length}");

                for (int i = 0; i < classNames.Length; i++)
                {
                    var probability = prediction.Score[i];
                    retorno.AppendLine($"{classNames[i]}: {probability:P2}");
                }
            }

            return retorno.ToString();
        }
    }
}