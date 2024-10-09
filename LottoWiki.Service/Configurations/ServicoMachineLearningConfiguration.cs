using LottoWiki.Service.Interfaces.MachineLearning.Consuming;
using LottoWiki.Service.Interfaces.MachineLearning.Training;
using LottoWiki.Service.Services.MachineLearning;
using LottoWiki.Service.Services.MachineLearning.Consuming;
using Microsoft.Extensions.DependencyInjection;

namespace LottoWiki.Service.Configurations
{
    public static class ServicoMachineLearningConfiguration
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<IDataConverter, DataConverter>();
            builder.AddScoped<ILightGbmApplying, LightGbmApplying>();
        }
    }
}