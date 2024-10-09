using Microsoft.ML.Data;

namespace LottoWiki.Service.ViewModels.MachineLearning
{
    public class LottoFacilLightGbm
    {
        [LoadColumn(1), ColumnName("MainSequence")]
        public string MainSequence { get; set; }

        [LoadColumn(2), ColumnName("NextLetter")]
        public string NextLetter { get; set; }
    }
}