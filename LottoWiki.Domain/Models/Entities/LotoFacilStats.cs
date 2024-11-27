namespace LottoWiki.Domain.Models.Entities
{
    public class LotoFacilStats
    {
        public int NumeroSorteado { get; set; }
        public int Periodo { get; set; }
        public int Intervalo { get; set; }
        public int Atraso { get; set; }
        public int Repeticao { get; set; }
        public double Frequencia { get; set; }
        public double DesvioPadrão { get; set; }
        public bool Ocorreu { get; set; }
    }
}