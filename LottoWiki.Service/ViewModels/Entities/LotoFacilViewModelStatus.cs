using LottoWiki.Service.ViewModels.Bases;

namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelStatus : LotoFacilViewModelBalls<char>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public LotoFacilViewModelStatus()
        {
        }
    }
}