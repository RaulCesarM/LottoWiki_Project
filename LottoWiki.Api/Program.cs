using LottoWiki.Data.Contexts;
using LottoWiki.Service.Configurations;
using LottoWiki.Service.Repositories;
using LottoWiki.Service.Workers;
using Microsoft.EntityFrameworkCore;

namespace LottoWiki.Api
{
    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;

                services.AddDbContext<LotofacilContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

                services.AddLogging(logging =>
                {
                    logging.AddConsole();
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.None); // Disable EF Core SQL logging
                });

                services.AddHostedService<LotoFacilWorkerSupplyBase>();
                services.AddHostedService<LotoFacilWorkerSupplyStatus>();
                services.AddHostedService<LotoFacilWorkerSupplyOverDue>();
                services.AddHostedService<LotoFacilWorkerSupplyDoOver>();

                services.AddSingleton(LotoFacilConfigurationsAutoMapper.Configure());

                LotoFacilConfigurationsBootstrapper.RegisterServices(services);
            });

            builder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var BASE = services.GetRequiredService<LotoFacilWorkerSupplyBase>();
                    BASE.StartAsync(default).GetAwaiter().GetResult();

                    var STATUS = services.GetRequiredService<LotoFacilWorkerSupplyStatus>();
                    STATUS.StartAsync(default).GetAwaiter().GetResult();

                    var OVERDUE = services.GetRequiredService<LotoFacilWorkerSupplyOverDue>();
                    OVERDUE.StartAsync(default).GetAwaiter().GetResult();

                    var DOOVER = services.GetRequiredService<LotoFacilWorkerSupplyDoOver>();
                    DOOVER.StartAsync(default).GetAwaiter().GetResult();

                    host.Run();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred while running the worker.");
                }
            }
        }
    }
}