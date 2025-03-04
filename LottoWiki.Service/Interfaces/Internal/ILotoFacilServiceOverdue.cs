﻿using LottoWiki.Service.Interfaces.Base;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.Internal
{
    public interface ILotoFacilServiceOverdue : IService<LotoFacilViewModelOverdue, int>
    {
        double GetGlobalStandardDeviation();

        double GetGlobalMeans();
    }
}