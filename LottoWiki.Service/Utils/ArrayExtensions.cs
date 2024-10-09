namespace LottoWiki.Service.Utils
{
    public static class ArrayExtensions
    {
        public static void InvertArray(this int[][] data)
        {
            int[][] temporaryArray = new int[25][];

            for (int i = 0, j = 24; i < 25; i++, j--)
            {
                temporaryArray[i] = data[j];
            }

            for (int i = 0; i < 25; i++)
            {
                data[i] = temporaryArray[i];
            }
        }

        public static void InvertArray(this double[][] data)
        {
            double[][] temporaryArray = new double[25][];

            for (int i = 0, j = 24; i < 25; i++, j--)
            {
                temporaryArray[i] = data[j];
            }

            for (int i = 0; i < 25; i++)
            {
                data[i] = temporaryArray[i];
            }
        }
    }
}