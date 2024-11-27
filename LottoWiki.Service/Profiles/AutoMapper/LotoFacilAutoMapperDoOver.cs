using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Domain.Models.Entities;
using AutoMapper;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapperDoOver : Profile
    {
        public LotoFacilAutoMapperDoOver()
        {
            CreateMap<LotoFacilDoOver, LotoFacilViewModelDoOver>().ReverseMap();
        }
    }
}