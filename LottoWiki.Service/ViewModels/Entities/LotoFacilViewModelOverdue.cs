using LottoWiki.Service.ViewModels.Bases;

namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelOverdue : LotoFacilViewModelBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public int Macro_Estado { get; set; }

        public LotoFacilViewModelOverdue()
        {
        }
    }
}