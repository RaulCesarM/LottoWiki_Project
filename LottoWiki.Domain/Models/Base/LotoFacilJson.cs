namespace LottoWiki.Domain.Models.Base
{
    public class LotoFacilJson
    {
        public int Numero { get; set; }
        public int NumeroConcursoAnterior { get; set; }
        public int NumeroConcursoProximo { get; set; }
        public string DataApuracao { get; set; }
        public string NomeMunicipioUFSorteio { get; set; }
        public List<int> DezenasSorteadasOrdemSorteio { get; set; }
    }
}