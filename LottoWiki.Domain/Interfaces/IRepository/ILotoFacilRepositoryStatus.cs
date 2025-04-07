using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilRepositoryStatus : IRepository<LotoFacilStatus>
    {
        Task<List<LotoFacilStatus>> GetEntityList(int id, int range);

        Task<string> GetEntityListAsString(int id);

        Task<char[]> GetByLuckyBall(int id, int col, int qtd);
    }
}