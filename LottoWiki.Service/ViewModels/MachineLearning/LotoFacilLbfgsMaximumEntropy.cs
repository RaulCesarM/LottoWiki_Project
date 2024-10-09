using Microsoft.ML.Data;

namespace LottoWiki.Service.ViewModels.MachineLearning
{
    public class LotoFacilLbfgsMaximumEntropy
    {
        [LoadColumn(0), ColumnName("PreviousSequence")]
        public string BeforeThreeSequenceMainSequence { get; set; }

        [LoadColumn(1), ColumnName("MainSequence")]
        public string ThreeSequenceMainSequence { get; set; }

        [LoadColumn(2), ColumnName("NextSequence")]
        public string NextSequence { get; set; }
    }
}