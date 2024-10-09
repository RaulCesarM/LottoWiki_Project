using LottoWiki.Service.Interfaces.MachineLearning.Consuming;
using LottoWiki.Service.ViewModels.MachineLearning;
using Microsoft.ML;
using System.Text;

namespace LottoWiki.Service.Services.MachineLearning.Consuming
{
    public class LightGbmApplying : ILightGbmApplying
    {
        private readonly string _modelFolder = Path.Combine("MachineLearning");

        private readonly string _modelPath;

        public LightGbmApplying()
        {
            _modelPath = Path.Combine(_modelFolder, "LightGbm.zip");

            if (!Directory.Exists(_modelFolder))
            {
                Directory.CreateDirectory(_modelFolder);
            }
        }

        public string PredictScoreLetter(string mainSequence) /// predição da proxima sequencia
        {
            var mlContextLetter = new MLContext();

            ITransformer trainedModel = mlContextLetter.Model.Load(_modelPath, out DataViewSchema modelSchema);
            var predictionEngine = mlContextLetter.Model.CreatePredictionEngine<LottoFacilLightGbm, PredictionModel>(trainedModel);

            var input = new LottoFacilLightGbm
            {
                MainSequence = mainSequence
            };

            var prediction = predictionEngine.Predict(input);
            var retorno = new StringBuilder();

            retorno.AppendLine($"Predicted Next Letter: {prediction.PredictedNextLetter}");

            if (prediction.Score != null && prediction.Score.Length > 0)
            {
                var classNames = new[] { "A", "N", "R" };
                for (int i = 0; i < classNames.Length; i++)
                {
                    if (i < prediction.Score.Length)
                    {
                        var probability = prediction.Score[i];
                        retorno.AppendLine($"{classNames[i]}: {probability:P2}");
                    }
                }
            }

            return retorno.ToString();
        }

        public string PredictLetter(string mainSequence)// predição de proxima letra
        {
            var mlContextLetter = new MLContext();

            ITransformer trainedModel = mlContextLetter.Model.Load(_modelPath, out DataViewSchema modelSchema);
            var predictionEngine = mlContextLetter.Model.CreatePredictionEngine<LottoFacilLightGbm, PredictionModel>(trainedModel);

            var input = new LottoFacilLightGbm
            {
                MainSequence = mainSequence
            };

            var prediction = predictionEngine.Predict(input);

            return prediction.PredictedNextLetter;
        }
    }
}