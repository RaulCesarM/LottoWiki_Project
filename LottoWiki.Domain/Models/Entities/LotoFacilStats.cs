namespace LottoWiki.Domain.Models.Entities
{
    public class LotoFacilStats
    {
        public int NumeroSorteado { get; set; }
        public int Atraso { get; set; }
        public int Repeticao { get; set; }
        public char Status { get; set; }
    }
}