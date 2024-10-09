using LottoWiki.Data.Contexts;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.MachineLearning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LottoWiki.Data.Repositories.Repositories
{
    public class LotoFacilRepositoryDataModel : ILotoFacilCommonRepositoryDataModel
    {
        private readonly LotofacilContext _context;
        private readonly ILogger<LotoFacilRepositoryDataModel> _logger;

        public LotoFacilRepositoryDataModel(LotofacilContext context, ILogger<LotoFacilRepositoryDataModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<LotoFacilDataModel> GetById(int id)
        {
            try
            {
                var response = await _context.Set<LotoFacilDataModel>()
                                             .FirstOrDefaultAsync(l => EF.Property<int>(l, "Id") == id);
                return response;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel buscar o resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public async Task Insert(LotoFacilDataModel entity)
        {
            try
            {
                await _context.Set<LotoFacilDataModel>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel inserir o resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public LotoFacilDataModel GetLast()
        {
            try
            {
                var lastEntity = _context.Set<LotoFacilDataModel>().OrderByDescending(x => x).FirstOrDefault();
                return lastEntity;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel buscar o ultimo resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }
    }
}