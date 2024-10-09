using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LottoWiki.Service.Workers
{
    public class LotoFacilWorkerDataModel : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public LotoFacilWorkerDataModel(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                int timeDelay = InitWorkerDataModel(scope);
                await Task.Delay(timeDelay, stoppingToken);
            }
        }

        private static int InitWorkerDataModel(IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var supplyServices = serviceProvider.GetRequiredService<ILotoFacilSupplyDataModel>();
            return supplyServices.HasNext() ? 1000 : 3600000;
        }
    }
}