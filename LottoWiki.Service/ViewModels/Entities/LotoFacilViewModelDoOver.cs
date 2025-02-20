using LottoWiki.Service.ViewModels.Bases;

namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelDoOver : LotoFacilViewModelBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public int Macro_Estado { get; set; }
        public double Media_Concurso { get; set; }
        public double Media_Global { get; set; }
        public double Desvio_Padrao_Concurso { get; set; }
        public double Desvio_Padrao_Global { get; set; }

        public LotoFacilViewModelDoOver()
        {
        }
    }
}