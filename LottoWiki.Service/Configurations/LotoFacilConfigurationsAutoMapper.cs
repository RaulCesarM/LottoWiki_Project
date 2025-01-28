using AutoMapper;

namespace LottoWiki.Service.Configurations
{
    public static class LotoFacilConfigurationsAutoMapper
    {
        public static IMapper Configure()
        {
            var configMap = new MapperConfiguration(config =>
            {
                config.AddProfile(new LotoFacilConfigurationsProfile());
            });
            return configMap.CreateMapper();
        }
    }
}