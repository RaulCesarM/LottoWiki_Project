using LottoWiki.Data.Contexts;
using LottoWiki.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Data.Repositories.Bases
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LotofacilContext _context;

        public Repository(LotofacilContext context)
        {
            _context = context;
        }

        public async Task Insert(TEntity entity)
        {
            try
            {
                var existingEntity = await _context.Set<TEntity>().FindAsync(
                    _context.Entry(entity).Property("Concurso").CurrentValue,
                    _context.Entry(entity).Property("ConcursoAnterior").CurrentValue,
                    _context.Entry(entity).Property("ProximoConcurso").CurrentValue);

                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    await _context.Set<TEntity>().AddAsync(entity);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel inserir o resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                var response = _context.Set<TEntity>().FirstOrDefault(l => EF.Property<int>(l, "Concurso") == id);
                return response;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel buscar o resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public TEntity GetLast()
        {
            try
            {
                var lastEntity = _context.Set<TEntity>().OrderByDescending(x => x).FirstOrDefault();
                return lastEntity;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel buscar o ultimo resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        public bool Exists(int id)
        {
            try
            {
                return _context.Set<TEntity>().Any(l => EF.Property<int>(l, "Concurso") == id);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Um erro ocorreu,  não foi possivel checar o resultado.";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }
    }
}