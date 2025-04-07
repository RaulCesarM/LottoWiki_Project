using Microsoft.ML.Data;

namespace LotoWiki.MachineLearning.Models
{
    public class StatusMLPredicao
    {
        [ColumnName("PredictedLabel")]
        public string ProximaLetraPrevista { get; set; } // Resultado da previsão
    }
}