using Microsoft.Extensions.DependencyInjection;
using LottoWiki.Service.Interfaces.Supply;
using Microsoft.Extensions.Hosting;

namespace LottoWiki.Service.Workers
{
    public class LotoFacilWorkerBase(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                int timeDelay = InitWorkerBase(scope);
                await Task.Delay(timeDelay, stoppingToken);
            }
        }

        private static int InitWorkerBase(IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var supplyServices = serviceProvider.GetRequiredService<ILotoFacilSupply>();
            return supplyServices.HasNext() ? 1000 : 10000;
        }
    }
}