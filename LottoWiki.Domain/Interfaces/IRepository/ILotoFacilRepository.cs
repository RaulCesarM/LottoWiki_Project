using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Domain.Interfaces.IRepository
{
    public interface ILotoFacilRepository : IRepository<LotoFacil>
    {
        Task<int> CountOccurrencesInRange(int ball, int range);

        Task<List<LotoFacil>> GetInRangeAsync(int range);

        Task<List<LotoFacil>> GetInRangeFromConcursoAsync(int concurso, int range);

        Task<int> GetFrequencyAsync(int numero, int concurso, int range);

        Task<int> GetRequiredContest(int numero, int concurso, int range);
    }
}