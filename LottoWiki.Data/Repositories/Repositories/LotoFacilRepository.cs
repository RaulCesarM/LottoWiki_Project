using LottoWiki.Data.Contexts;
using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepository : BaseRepository<LotoFacil>, ILotoFacilCommonRepository
    {
        private readonly LotofacilContext _context;

        public LotoFacilRepository(LotofacilContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountOccurrencesInRange(int ball, int range)
        {
            int count = 0;

            try
            {
                var entities = await _context.Set<LotoFacil>()
                    .OrderByDescending(l => l.Concurso)
                    .Take(range + 1)
                    .ToListAsync();

                for (int i = 1; i <= 15; i++)
                {
                    string propertyName = $"Casa_{(i <= 9 ? "0" : "")}{i}";

                    foreach (var item in entities)
                    {
                        var propertyValue = (int)item.GetType().GetProperty(propertyName).GetValue(item);
                        if (propertyValue == ball)
                        {
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu ao contar ocorrências para o número {ball} no intervalo de {range} concursos.";
                throw new InvalidOperationException(errorMessage, ex);
            }

            return count;
        }

        public async Task<List<LotoFacil>> GetInRangeAsync(int range)
        {
            List<LotoFacil> entities = [];

            try
            {
                entities = await _context.Set<LotoFacil>()
                     .OrderByDescending(l => l.Concurso)
                     .Take(range + 1)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu, {entities} permanece vazia.";
                throw new InvalidOperationException(errorMessage, ex);
            }

            return entities;
        }
    }
}