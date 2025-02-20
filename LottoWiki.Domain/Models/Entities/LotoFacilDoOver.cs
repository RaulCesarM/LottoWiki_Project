using LottoWiki.Domain.Models.Base;

namespace LottoWiki.Domain.Models.Entities
{
    public class LotoFacilDoOver : LotoFacilBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public int Macro_Estado { get; set; }
        public double Media_Concurso { get; set; }
        public double Media_Global { get; set; }
        public double Desvio_Padrao_Concurso { get; set; }
        public double Desvio_Padrao_Global { get; set; }

        public LotoFacilDoOver()
        {
        }
    }
}