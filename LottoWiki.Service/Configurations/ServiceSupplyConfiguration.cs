using LottoWiki.Service.Interfaces.Supply;
using LottoWiki.Service.Services.LotoFacilSupply;
using Microsoft.Extensions.DependencyInjection;

namespace LottoWiki.Service.Configurations
{
    public static class ServiceSupplyConfiguration
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ILotoFacilSupply, LotoFacilSupply>();
            builder.AddScoped<ILotoFacilSupplyOverdue, LotoFacilSupplyOverdue>();
            builder.AddScoped<ILotoFacilSupplyStatus, LotoFacilSupplyStatus>();
        }
    }
}