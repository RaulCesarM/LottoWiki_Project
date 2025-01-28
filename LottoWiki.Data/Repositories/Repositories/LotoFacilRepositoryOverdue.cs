using LottoWiki.Data.Contexts;
using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepositoryOverdue : Repository<LotoFacilOverdue>, ILotoFacilRepositoryOverdue
    {
        private readonly LotofacilContext _context;

        public LotoFacilRepositoryOverdue(LotofacilContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LotoFacilOverdue>> GetEntityList(int id)
        {
            List<LotoFacilOverdue> entities = [];

            try
            {
                entities = await _context.Set<LotoFacilOverdue>()
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

        public async Task<List<LotoFacilOverdue>> GetEntityListInRange(int id, int range)
        {
            List<LotoFacilOverdue> entities = [];
            try
            {
                entities = await _context.Set<LotoFacilOverdue>()
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