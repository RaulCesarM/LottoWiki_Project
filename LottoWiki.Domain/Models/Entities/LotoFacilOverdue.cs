﻿using LottoWiki.Domain.Models.Base;

namespace LottoWiki.Domain.Models.Entities
{
    public class LotoFacilOverdue : LotoFacilBalls<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public int Macro_Estado { get; set; }
        public double MediaConcurso { get; set; }
        public double MediaGlobal { get; set; }
        public double DesvioPadraoConcurso { get; set; }
        public double DesvioPadraoGlobal { get; set; }

        public LotoFacilOverdue()
        {
        }
    }
}