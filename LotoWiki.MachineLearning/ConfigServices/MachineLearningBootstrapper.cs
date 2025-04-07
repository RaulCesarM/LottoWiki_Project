using LotoWiki.MachineLearning.Interfaces;
using LotoWiki.MachineLearning.Training;
using Microsoft.Extensions.DependencyInjection;

namespace LotoWiki.MachineLearning.ConfigServices
{
    public static class MachineLearningBootstrapper
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ITraining, StatusTraining>();
            builder.AddScoped<IConsumir, Consumir>();
        }
    }
}