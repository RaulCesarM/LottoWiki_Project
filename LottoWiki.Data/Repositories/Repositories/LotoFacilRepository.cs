using LottoWiki.Data.Contexts;
using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepository : Repository<LotoFacil>, ILotoFacilRepository
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

        public async Task<List<LotoFacil>> GetInRangeFromConcursoAsync(int concurso, int range)
        {
            try
            {
                List<LotoFacil> entities = await _context.Set<LotoFacil>()
                    .Where(l => l.Concurso <= concurso)
                    .OrderByDescending(l => l.Concurso)
                    .Take(range + 1)
                    .ToListAsync();
                return entities;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Erro ao buscar os {range} concursos anteriores ao concurso {concurso}.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public async Task<int> GetFrequencyAsync(int numero, int concurso, int range)
        {
            try
            {
                List<LotoFacil> entities = await _context.Set<LotoFacil>()
                    .Where(l => l.Concurso <= concurso)
                    .OrderByDescending(l => l.Concurso)
                    .Take(range)
                    .ToListAsync();

                int frequency = entities
                    .SelectMany(l => new[] {
                        l.Casa_01,
                        l.Casa_02,
                        l.Casa_03,
                        l.Casa_04,
                        l.Casa_05,
                        l.Casa_06,
                        l.Casa_07,
                        l.Casa_08,
                        l.Casa_09,
                        l.Casa_10,
                        l.Casa_11,
                        l.Casa_12,
                        l.Casa_13,
                        l.Casa_14,
                        l.Casa_15 })
                    .Count(casa => casa == numero);

                return frequency;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Erro ao buscar a frequência do número {numero} nos últimos {range} concursos.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public async Task<int> GetRequiredContest(int numero, int concurso, int targetFrequency)
        {
            try
            {
                int frequency = 0;
                int countDraws = 0;

                var query = _context.Set<LotoFacil>()
                    .Where(l => l.Concurso <= concurso)
                    .OrderByDescending(l => l.Concurso);

                await foreach (var draw in query.AsAsyncEnumerable())
                {
                    frequency += new[] {
                        draw.Casa_01,
                        draw.Casa_02,
                        draw.Casa_03,
                        draw.Casa_04,
                        draw.Casa_05,
                        draw.Casa_06,
                        draw.Casa_07,
                        draw.Casa_08,
                        draw.Casa_09,
                        draw.Casa_10,
                        draw.Casa_11,
                        draw.Casa_12,
                        draw.Casa_13,
                        draw.Casa_14,
                        draw.Casa_15 }.Count(casa => casa == numero);

                    countDraws++;

                    if (frequency >= targetFrequency)
                        return countDraws;
                }

                return -1;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Erro ao calcular quantos concursos são necessários para o número {numero} aparecer {targetFrequency} vezes.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }
    }
}