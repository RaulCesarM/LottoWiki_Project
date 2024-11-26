using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Services.ExternalServices;
using LottoWiki.Service.Services.InternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace LottoWiki.Service.QueryServices
{
    public static class ServiceConfigurations
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ILotoFacilService, LotoFacilService>();
            builder.AddScoped<ILotoFacilServiceOverdue, LotoFacilServiceOverdue>();
            builder.AddScoped<ILotoFacilServiceStatus, LotoFacilServiceStatus>();
            builder.AddScoped<ILotoFacilQueryCorrelation, LotoFacilQueryCorrelation>();
            builder.AddScoped<ILotoFacilQueryOverdue, LotoFacilQueryOverdue>();
            builder.AddScoped<ILotoFacilQueryOcurrences, LotoFacilQueryOcurrences>();
            builder.AddScoped<ILotoFacilQueryLunation, LofoFacilQueryLunation>();
            builder.AddScoped<ILotoFacilQueryStatus, LotoFacilQueryStatus>();
        }
    }
}