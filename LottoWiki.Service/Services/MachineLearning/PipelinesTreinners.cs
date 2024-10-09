using LottoWiki.Service.ViewModels.MachineLearning;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

namespace LottoWiki.Service.Services.MachineLearning
{
    public class PipelinesTreinners
    {
        public static EstimatorChain<KeyToValueMappingTransformer> GetLightGbmPipeline(MLContext mlContext)
        {
            return mlContext.Transforms.Text.FeaturizeText("PreviousSequenceFeatures", nameof(LotoFacilLbfgsMaximumEntropy.BeforeThreeSequenceMainSequence))
                .Append(mlContext.Transforms.Text.FeaturizeText("MainSequenceFeatures", nameof(LotoFacilLbfgsMaximumEntropy.ThreeSequenceMainSequence)))
                .Append(mlContext.Transforms.Concatenate("Features", "PreviousSequenceFeatures", "MainSequenceFeatures"))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(LotoFacilLbfgsMaximumEntropy.NextSequence)))
                .Append(mlContext.MulticlassClassification.Trainers.LightGbm(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
        }

        public static EstimatorChain<KeyToValueMappingTransformer> LbfgsMaximumEntropyPipeline(MLContext mlContext)
        {
            return mlContext.Transforms.Text.FeaturizeText("PreviousSequenceFeatures", nameof(LotoFacilLbfgsMaximumEntropy.BeforeThreeSequenceMainSequence))
                .Append(mlContext.Transforms.Text.FeaturizeText("MainSequenceFeatures", nameof(LotoFacilLbfgsMaximumEntropy.ThreeSequenceMainSequence)))
                .Append(mlContext.Transforms.Concatenate("Features", "PreviousSequenceFeatures", "MainSequenceFeatures"))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(LotoFacilLbfgsMaximumEntropy.NextSequence)))
                .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
        }

        public static EstimatorChain<KeyToValueMappingTransformer> LbfgsLogisticRegressionPipeline(MLContext mlContext)
        {
            return mlContext.Transforms.Text.FeaturizeText("PreviousSequenceFeatures", nameof(LotoFacilLbfgsLogisticRegression.VerticalSequence))
                .Append(mlContext.Transforms.Text.FeaturizeText("MainSequenceFeatures", nameof(LotoFacilLbfgsLogisticRegression.MainSequence)))
                .Append(mlContext.Transforms.Concatenate("Features", "PreviousSequenceFeatures", "MainSequenceFeatures"))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(LotoFacilLbfgsLogisticRegression.NextLetter)))
                .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
        }
    }
}