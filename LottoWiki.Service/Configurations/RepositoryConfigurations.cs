using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Data.Repositories.Repositories;
using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Interfaces.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LottoWiki.Service.Repositories
{
    public static class RepositoryConfigurations
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.AddScoped<ILotoFacilCommonRepository, LotoFacilRepository>();
            builder.AddScoped<ILotoFacilCommonRepositoryOverdue, LotoFacilRepositoryOverdue>();
            builder.AddScoped<ILotoFacilCommonRepositoryStatus, LotoFacilRepositoryStatus>();
        }
    }
}