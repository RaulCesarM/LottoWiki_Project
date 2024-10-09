using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

namespace LottoWiki.Service.Services.MachineLearning
{
    public class EstimatorTreinners
    {
        public static (TransformerChain<KeyToValueMappingTransformer> Model, MulticlassClassificationMetrics Metrics) AddLightGbmEstimator(MLContext mlContext, DataOperationsCatalog.TrainTestData splitData)
        {
            var pipeline = PipelinesTreinners.GetLightGbmPipeline(mlContext);
            var model = pipeline.Fit(splitData.TrainSet);
            var predictions = model.Transform(splitData.TestSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions, labelColumnName: "Label");

            return (model, metrics);
        }

        public static (TransformerChain<KeyToValueMappingTransformer> Model, MulticlassClassificationMetrics Metrics) LbfgsMaximumEntropyEstimator(MLContext mlContext, DataOperationsCatalog.TrainTestData splitData)
        {
            var pipeline = PipelinesTreinners.LbfgsMaximumEntropyPipeline(mlContext);
            var model = pipeline.Fit(splitData.TrainSet);
            var predictions = model.Transform(splitData.TestSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions, labelColumnName: "Label");

            return (model, metrics);
        }

        public static (TransformerChain<KeyToValueMappingTransformer> Model, MulticlassClassificationMetrics Metrics) LbfgsLogisticRegressionEstimator(MLContext mlContext, DataOperationsCatalog.TrainTestData splitData)
        {
            var pipeline = PipelinesTreinners.LbfgsLogisticRegressionPipeline(mlContext);
            var model = pipeline.Fit(splitData.TrainSet);
            var predictions = model.Transform(splitData.TestSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions, labelColumnName: "Label");

            return (model, metrics);
        }
    }
}