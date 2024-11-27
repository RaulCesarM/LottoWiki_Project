namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilStatsViewModel
    {
        public int NumeroSorteado { get; set; }
        public int Periodo { get; set; }
        public int Intervalo { get; set; }
        public int Atraso { get; set; }
        public double Frequencia { get; set; }
        public double DesvioPadrão { get; set; }
        public bool Ocorreu { get; set; }
    }
}