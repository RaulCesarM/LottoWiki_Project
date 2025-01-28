namespace LottoWiki.Domain.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity);

        TEntity GetById(int id);

        TEntity GetLast();

        bool Exists(int id);
    }
}