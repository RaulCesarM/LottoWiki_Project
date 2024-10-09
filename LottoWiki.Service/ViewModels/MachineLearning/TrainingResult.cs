namespace LottoWiki.Service.ViewModels.MachineLearning
{
    public class TrainingResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ModelPath { get; set; }
    }
}