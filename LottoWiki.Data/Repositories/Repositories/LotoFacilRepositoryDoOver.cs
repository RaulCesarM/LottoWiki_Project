using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using LottoWiki.Data.Contexts;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepositoryDoOver : Repository<LotoFacilDoOver>, ILotoFacilRepositoryDoOver
    {
        private readonly LotofacilContext _context;

        public LotoFacilRepositoryDoOver(LotofacilContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LotoFacilDoOver>> GetEntityList(int id)
        {
            List<LotoFacilDoOver> entities = [];

            try
            {
                entities = await _context.Set<LotoFacilDoOver>()
                                   .Where(e => e.Concurso <= id)
                                   .OrderByDescending(e => e.Concurso)
                                   .ToListAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  {entities} permanece vazia.";
                throw new InvalidOperationException(errorMessage, ex);
            }

            return entities;
        }

        public async Task<List<LotoFacilDoOver>> GetEntityListInRange(int id, int range)
        {
            List<LotoFacilDoOver> entities = [];
            try
            {
                entities = await _context.Set<LotoFacilDoOver>()
                                   .Where(e => e.Concurso <= id)
                                   .OrderByDescending(e => e.Concurso)
                                   .Take(range)
                                   .ToListAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  {entities} permanece vazia.";
                throw new InvalidOperationException(errorMessage, ex);
            }

            return entities;
        }
    }
}