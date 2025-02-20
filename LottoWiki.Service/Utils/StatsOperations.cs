namespace LottoWiki.Service.Utils
{
    public static class StatsOperations
    {
        public static double CalcularDesvioPadrao(List<int> valores, bool populacional = true)
        {
            if (valores == null || valores.Count == 0)
                throw new ArgumentException("A lista de valores não pode estar vazia.");

            double media = valores.Average();
            double somaQuadrados = valores.Sum(x => Math.Pow(x - media, 2));

            int divisor = populacional ? valores.Count : valores.Count - 1;
            return Math.Sqrt(somaQuadrados / divisor);
        }

        public static double CalcularDesvioPadrao(List<double> valores, bool populacional = true)
        {
            if (valores == null || valores.Count == 0)
                throw new ArgumentException("A lista de valores não pode estar vazia.");

            double media = valores.Average();
            double somaQuadrados = valores.Sum(x => Math.Pow(x - media, 2));

            int divisor = populacional ? valores.Count : valores.Count - 1;
            return Math.Sqrt(somaQuadrados / divisor);
        }
    }
}