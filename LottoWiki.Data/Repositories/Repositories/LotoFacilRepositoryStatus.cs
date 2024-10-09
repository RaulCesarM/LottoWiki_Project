using LottoWiki.Data.Contexts;
using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepositoryStatus : BaseRepository<LotoFacilStatus>, ILotoFacilCommonRepositoryStatus
    {
        private readonly LotofacilContext _context;

        public LotoFacilRepositoryStatus(LotofacilContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LotoFacilStatus>> GetEntityList(int id, int range)
        {
            List<LotoFacilStatus> entities = [];

            try
            {
                entities = await _context.Set<LotoFacilStatus>()
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

        public async Task<string> GetEntityListAsString(int id)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder result = new StringBuilder();

            query.AppendLine("SELECT [Concurso], [ConcursoAnterior], [ProximoConcurso]");
            query.AppendLine(",[Bola_01], [Bola_02], [Bola_03], [Bola_04], [Bola_05]");
            query.AppendLine(",[Bola_06], [Bola_07], [Bola_08], [Bola_09], [Bola_10]");
            query.AppendLine(",[Bola_11], [Bola_12], [Bola_13], [Bola_14], [Bola_15]");
            query.AppendLine(",[Bola_16], [Bola_17], [Bola_18], [Bola_19], [Bola_20]");
            query.AppendLine(",[Bola_21], [Bola_22], [Bola_23], [Bola_24], [Bola_25]");
            query.AppendLine("FROM [lottowiki].[dbo].[bola.status]");
            query.AppendFormat($"WHERE [Concurso] = {id}");

            try
            {
                var entities = await _context.Set<LotoFacilStatus>()
                    .FromSqlRaw(query.ToString())
                    .ToListAsync();

                foreach (var entity in entities)
                {
                    result.AppendLine($"{entity.Bola_01}{entity.Bola_02}{entity.Bola_03}{entity.Bola_04}{entity.Bola_05}" +
                                       $"{entity.Bola_06}{entity.Bola_07}{entity.Bola_08}{entity.Bola_09}{entity.Bola_10}" +
                                       $"{entity.Bola_11}{entity.Bola_12}{entity.Bola_13}{entity.Bola_14}{entity.Bola_15}" +
                                       $"{entity.Bola_16}{entity.Bola_17}{entity.Bola_18}{entity.Bola_19}{entity.Bola_20}" +
                                       $"{entity.Bola_21}{entity.Bola_22}{entity.Bola_23}{entity.Bola_24}{entity.Bola_25}");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Um erro ocorreu ao tentar buscar os dados.";
                throw new InvalidOperationException(errorMessage, ex);
            }

            return result.ToString();
        }
    }
}