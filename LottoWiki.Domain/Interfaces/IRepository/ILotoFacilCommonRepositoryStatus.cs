﻿using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilCommonRepositoryStatus : IBaseRepository<LotoFacilStatus>
    {
        Task<List<LotoFacilStatus>> GetEntityList(int id, int range);

        Task<string> GetEntityListAsString(int id);
    }
}