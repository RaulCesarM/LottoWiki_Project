namespace LottoWiki.Service.Interfaces.MachineLearning.Consuming
{
    public interface ILightGbmApplying
    {
        string PredictScoreLetter(string mainSequence);

        string PredictLetter(string mainSequence);
    }
}