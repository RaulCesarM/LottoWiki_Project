using LottoWiki.Domain.Models.Base;

namespace LottoWiki.Domain.Models.Entities
{
    public class LotoFacilDoOver : LotoFacilBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public LotoFacilDoOver()
        {
        }
    }
}