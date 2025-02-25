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

        public async Task<List<int>> GetGlobalStandardDeviation()
        {
            try
            {
                var allBalls = await _context.Set<LotoFacilOverdue>()
                    .Select(x => new int[]
                    {
                x.Bola_01,
                x.Bola_02,
                x.Bola_03,
                x.Bola_04,
                x.Bola_05,
                x.Bola_06,
                x.Bola_07,
                x.Bola_08,
                x.Bola_09,
                x.Bola_10,
                x.Bola_11,
                x.Bola_12,
                x.Bola_13,
                x.Bola_14,
                x.Bola_15,
                x.Bola_16,
                x.Bola_17,
                x.Bola_18,
                x.Bola_19,
                x.Bola_20,
                x.Bola_21,
                x.Bola_22,
                x.Bola_23,
                x.Bola_24,
                x.Bola_25
                    })
                    .ToListAsync();
                var flattenedBalls = allBalls.SelectMany(x => x).ToList();
                return flattenedBalls;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao calcular o desvio padrão global.", ex);
            }
        }

        public async Task<List<int>> GetGlobalMeans()
        {
            try
            {
                var allBalls = await _context.Set<LotoFacilOverdue>()
                    .Select(x => new int[]
                    {
                x.Bola_01,
                x.Bola_02,
                x.Bola_03,
                x.Bola_04,
                x.Bola_05,
                x.Bola_06,
                x.Bola_07,
                x.Bola_08,
                x.Bola_09,
                x.Bola_10,
                x.Bola_11,
                x.Bola_12,
                x.Bola_13,
                x.Bola_14,
                x.Bola_15,
                x.Bola_16,
                x.Bola_17,
                x.Bola_18,
                x.Bola_19,
                x.Bola_20,
                x.Bola_21,
                x.Bola_22,
                x.Bola_23,
                x.Bola_24,
                x.Bola_25
                    })
                    .ToListAsync();
                var flattenedBalls = allBalls.SelectMany(x => x).ToList();
                return flattenedBalls;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao calcular a média global.", ex);
            }
        }
    }
}