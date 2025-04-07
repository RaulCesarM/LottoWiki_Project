using LotoWiki.MachineLearning.Interfaces;
using LotoWiki.MachineLearning.Models;
using Microsoft.ML;

namespace LotoWiki.MachineLearning.Training
{
    public class Consumir : IConsumir
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _modelo;
        private readonly PredictionEngine<StatusML, StatusMLPredicao> _predictionEngine;
        private const string ModeloPath = "modelo_status.zip";

        public Consumir()
        {
            _mlContext = new MLContext();

            // Carrega o modelo treinado
            if (!File.Exists(ModeloPath))
                throw new FileNotFoundException($"Modelo não encontrado: {ModeloPath}");

            _modelo = _mlContext.Model.Load(ModeloPath, out _);

            // Cria um mecanismo de previsão
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<StatusML, StatusMLPredicao>(_modelo);
        }

        public string Prever(string sequencia)
        {
            var entrada = new StatusML { Sequencia = sequencia };
            var resultado = _predictionEngine.Predict(entrada);
            return resultado.ProximaLetraPrevista;
        }
    }
}