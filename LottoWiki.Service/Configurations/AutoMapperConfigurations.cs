using AutoMapper;
using LottoWiki.Service.Profiles.AutoMapper;

namespace LottoWiki.Service.Configurations
{
    public static class AutoMapperConfigurations
    {
        public static IMapper Configure()
        {
            var configMap = new MapperConfiguration(config =>
            {
                config.AddProfile(new LotoFacilAutoMapper());
                config.AddProfile(new LotoFacilAutoMapperOverdue());
                config.AddProfile(new LotoFacilAutoMapperDoOver());
                config.AddProfile(new LotoFacilAutoMapperStatus());
            });
            return configMap.CreateMapper();
        }
    }
}