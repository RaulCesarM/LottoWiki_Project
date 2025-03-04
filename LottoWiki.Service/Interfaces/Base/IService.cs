﻿namespace LottoWiki.Service.Interfaces.Base
{
    public interface IService<TEntity, in Tkey> where TEntity : class
    {
        TEntity GetById(Tkey key);

        TEntity GetLast();

        Task Insert(TEntity entity);

        int GetLastId();

        int GetNextId();

        int GetPreviusId();

        bool Exists(int id);
    }
}