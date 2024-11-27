﻿using LottoWiki.Service.ViewModels.Bases;

namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelDoOver : LotoFacilBallsViewModel<int>
    {
        public int Concurso { get; set; }
        public int ConcursoAnterior { get; set; }
        public int ProximoConcurso { get; set; }

        public LotoFacilViewModelDoOver()
        {
        }
    }
}