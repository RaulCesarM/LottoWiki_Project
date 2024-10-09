using Microsoft.ML.Data;

namespace LottoWiki.Service.ViewModels.MachineLearning
{
    public class PredictionModel
    {
        [ColumnName("PredictedLabel")]
        public string PredictedNextLetter { get; set; }

        public float[] Score { get; set; }
    }
}