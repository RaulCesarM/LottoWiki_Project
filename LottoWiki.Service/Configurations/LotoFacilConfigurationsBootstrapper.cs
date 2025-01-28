using LottoWiki.Data.Repositories.Bases;
using LottoWiki.Data.Repositories.Repositories;
using LottoWiki.Domain.Interfaces.Base;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Interfaces.Supply;
using LottoWiki.Service.Services.ExternalServices;
using LottoWiki.Service.Services.InternalServices;
using LottoWiki.Service.Services.LotoFacilSupply;
using LottoWiki.Service.Services.SupplyServices;
using Microsoft.Extensions.DependencyInjection;

namespace LottoWiki.Service.Repositories
{
    public static class LotoFacilConfigurationsBootstrapper
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            /* Repository */
            builder.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.AddScoped<ILotoFacilRepository, LotoFacilRepository>();
            builder.AddScoped<ILotoFacilRepositoryOverdue, LotoFacilRepositoryOverdue>();
            builder.AddScoped<ILotoFacilRepositoryDoOver, LotoFacilRepositoryDoOver>();
            builder.AddScoped<ILotoFacilRepositoryStatus, LotoFacilRepositoryStatus>();

            /* Services */
            builder.AddScoped<ILotoFacilService, LotoFacilService>();
            builder.AddScoped<ILotoFacilServiceOverdue, LotoFacilServiceOverdue>();
            builder.AddScoped<ILotoFacilServiceDoOver, LotoFacilServiceDoOver>();
            builder.AddScoped<ILotoFacilServiceStatus, LotoFacilServiceStatus>();
            builder.AddScoped<ILotoFacilQueryCorrelation, LotoFacilQueryCorrelation>();
            builder.AddScoped<ILotoFacilQueryOverdue, LotoFacilQueryOverdue>();
            builder.AddScoped<ILotoFacilQueryLunation, LofoFacilQueryLunation>();
            builder.AddScoped<ILotoFacilQueryStatus, LotoFacilQueryStatus>();
            builder.AddScoped<ILotoFacilQueryDataToText, LotoFacilQueryDataToText>();
            builder.AddScoped<ILotoFacilQueryOcurrences, LotoFacilQueryOcurrences>();
            builder.AddScoped<ILotoFacilQueryDoOver, LotoFacilQueryDoOver>();

            /* Supplier */
            builder.AddScoped<ILotoFacilSupply, LotoFacilSupply>();
            builder.AddScoped<ILotoFacilSupplyOverdue, LotoFacilSupplyOverdue>();
            builder.AddScoped<ILotoFacilSupplyDoOver, LotoFacilSupplyDoOver>();
            builder.AddScoped<ILotoFacilSupplyStatus, LotoFacilSupplyStatus>();
        }
    }
}