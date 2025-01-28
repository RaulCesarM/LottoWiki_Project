using Microsoft.Extensions.DependencyInjection;
using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.Hosting;

namespace LottoWiki.Service.Workers
{
    public class LotoFacilWorkerSupplyStatus(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                int timeDelay = InitWorkerStatus(scope);
                await Task.Delay(timeDelay, stoppingToken);
            }
        }

        private static int InitWorkerStatus(IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var supplyServices = serviceProvider.GetRequiredService<ILotoFacilSupplyStatus>();
            return supplyServices.HasNext() ? 1000 : 10000;
        }
    }
}