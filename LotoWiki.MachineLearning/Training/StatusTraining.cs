using LotoWiki.MachineLearning.Interfaces;
using LotoWiki.MachineLearning.Models;
using LottoWiki.Service.Interfaces.External;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.LightGbm;
using System.Data;

namespace LotoWiki.MachineLearning.Training
{
    public class StatusTraining : ITraining
    {
        private const string ModeloPath = "modelo_status.zip";
        private readonly MLContext _contextoML;
        private readonly ILotoFacilQueryStatus _service;
        private ITransformer? _modeloTreinado;
        private List<StatusML> _models = new();

        public StatusTraining(ILotoFacilQueryStatus service, MLContext contextoML)
        {
            _contextoML = contextoML;
            _service = service;
        }

        public ITransformer? CarregarModelo()
        {
            if (!File.Exists(ModeloPath)) return null;
            using var stream = new FileStream(ModeloPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return _contextoML.Model.Load(stream, out _);
        }

        public void PrepararModelo()
        {
            _models = PopulateStatusData();
            _modeloTreinado = TreinarModelo(_models);
            SalvarModelo();
        }

        private List<StatusML> PopulateStatusData()
        {
            var statusData = new List<StatusML>();

            for (int col = 1; col <= 25; col++)
            {
                for (int conc = 2000; conc < 2200; conc++)
                {
                    var status = _service.GetByLuckyBall(conc, col, 4);

                    statusData.Add(new StatusML
                    {
                        Sequencia = new string(status[..^1]),
                        ProximaLetra = status[^1].ToString()
                    });
                }
            }
            return statusData;
        }

        private void SalvarModelo()
        {
            if (_modeloTreinado != null)
            {
                using var stream = new FileStream(ModeloPath, FileMode.Create, FileAccess.Write, FileShare.None);
                _contextoML.Model.Save(_modeloTreinado, null, stream);
            }
        }

        private ITransformer TreinarModelo(List<StatusML> dados)
        {
            var dataView = _contextoML.Data.LoadFromEnumerable(dados);

            var pipeline = _contextoML.Transforms.Conversion.MapValueToKey("Label", nameof(StatusML.ProximaLetra))
                .Append(_contextoML.Transforms.Text.FeaturizeText("Features", nameof(StatusML.Sequencia)))
                .Append(_contextoML.MulticlassClassification.Trainers.LightGbm("Label", "Features"))
                .Append(_contextoML.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            return pipeline.Fit(dataView);
        }

        //private ITransformer TreinarModelo(List<StatusML> dados)
        //{
        //    var dataView = _contextoML.Data.LoadFromEnumerable(dados);

        //    var pipeline = _contextoML.Transforms.Conversion.MapValueToKey(
        //            outputColumnName: "Label",
        //            inputColumnName: nameof(StatusML.ProximaLetra))

        //        // Processamento otimizado para sequências de caracteres
        //        .Append(_contextoML.Transforms.Text.TokenizeIntoCharactersAsKeys(
        //            outputColumnName: "Chars",
        //            inputColumnName: nameof(StatusML.Sequencia)))

        //        // Geração de n-grams (captura padrões sequenciais)
        //        .Append(_contextoML.Transforms.Text.ProduceNgrams(
        //            outputColumnName: "Ngrams",
        //            inputColumnName: "Chars",
        //            ngramLength: 3,  // Trigramas para capturar contextos curtos
        //            skipLength: 0,
        //            useAllLengths: false))

        //        // Vetorização final
        //        .Append(_contextoML.Transforms.Text.FeaturizeText(
        //            outputColumnName: "Features",
        //            inputColumnName: "Ngrams"))

        //        // Modelo SDCA com hiperparâmetros ajustados
        //        .Append(_contextoML.MulticlassClassification.Trainers.SdcaMaximumEntropy(
        //            new SdcaMaximumEntropyMulticlassTrainer.Options
        //            {
        //                LabelColumnName = "Label",
        //                FeatureColumnName = "Features",
        //                L2Regularization = 0.1f,    // Controle de overfitting
        //                L1Regularization = 0.01f,   // Para seleção de features
        //                ConvergenceTolerance = 0.01f,
        //                MaximumNumberOfIterations = 200,
        //                BiasLearningRate = 0.1f,   // Importante para classes desbalanceadas
        //                Shuffle = true              // Melhora a generalização
        //            }))

        //        .Append(_contextoML.Transforms.Conversion.MapKeyToValue(
        //            outputColumnName: "PredictedLabel"));

        //    return pipeline.Fit(dataView);
        //}
    }
}