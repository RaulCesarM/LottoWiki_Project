namespace LottoWiki.Service.Utils
{
    public static class BallNameFormatter
    {
        public static string FormatBallName(string prefix, int ball)
        {
            return $"{prefix}_{ball:D2}";
        }
    }
}