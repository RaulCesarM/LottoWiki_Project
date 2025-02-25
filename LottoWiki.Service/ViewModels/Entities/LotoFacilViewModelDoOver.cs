using LottoWiki.Service.ViewModels.Bases;

namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelDoOver : LotoFacilViewModelBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public int Macro_Estado { get; set; }
        public double MediaConcurso { get; set; }
        public double MediaGlobal { get; set; }
        public double DesvioPadraoConcurso { get; set; }
        public double DesvioPadraoGlobal { get; set; }

        public LotoFacilViewModelDoOver()
        {
        }
    }
}