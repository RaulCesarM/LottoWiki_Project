using Microsoft.ML.Data;

namespace LotoWiki.MachineLearning.Models
{
    public class StatusML
    {
        [LoadColumn(0)]
        public string Sequencia { get; set; }  // Exemplo: "AAAAAN"

        [LoadColumn(1)]
        public string ProximaLetra { get; set; } // Exemplo: "R"
    }
}