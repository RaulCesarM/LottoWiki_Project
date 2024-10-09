using LottoWiki.Service.ViewModels.MachineLearning;
using System.Text;

namespace LottoWiki.Service.Utils
{
    public static class DataModelTransformator
    {
        public static LottoFacilLightGbm ConvertLightGbm(this LotoFacilDataModelViewModel dataModel)
        {
            LottoFacilLightGbm model = new()
            {
                MainSequence = dataModel.ThreeSequence,
                NextLetter = dataModel.NextLetter
            };

            return model;
        }

        public static LotoFacilLbfgsMaximumEntropy ConvertLbfgsMaximumEntropy(this LotoFacilDataModelViewModel dataModel)
        {
            var sequence = new StringBuilder();
            sequence.Append(dataModel.VerticalSequence);
            sequence.Append(dataModel.NextLetter);
            var sequenceStr = sequence.ToString();

            LotoFacilLbfgsMaximumEntropy model = new()
            {
                BeforeThreeSequenceMainSequence = sequenceStr.Substring(1, 3),
                ThreeSequenceMainSequence = sequenceStr.Substring(4, 3),
                NextSequence = sequenceStr.Substring(7, 3),
            };

            return model;
        }

        public static LotoFacilLbfgsLogisticRegression ConvertLbfgsLogisticRegression(this LotoFacilDataModelViewModel dataModel)
        {
            LotoFacilLbfgsLogisticRegression model = new()
            {
                VerticalSequence = dataModel.VerticalSequence,
                MainSequence = dataModel.ThreeSequence,
                NextLetter = dataModel.NextLetter
            };

            return model;
        }
    }
}