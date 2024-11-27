namespace LottoWiki.Service.ViewModels.Bases
{
    public class LotoFacilHeadViewModel
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }
        public string DataApuracao { get; set; }
        public string NomeMunicipioUFSorteio { get; set; }
        public string LuaDoSorteio { get; set; }
    }
}