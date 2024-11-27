using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LottoWiki.Service.Workers
{
    public class LotoFacilWorkerSupplyDoOver(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                int timeDelay = InitSupplyDoOver(scope);
                await Task.Delay(timeDelay, stoppingToken);
            }
        }

        private static int InitSupplyDoOver(IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var supplyServices = serviceProvider.GetRequiredService<ILotoFacilSupplyDoOver>();
            return supplyServices.HasNext() ? 1000 : 10000;
        }
    }
}