using AutoMapper;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapperStatus : Profile
    {
        public LotoFacilAutoMapperStatus()
        {
            CreateMap<LotoFacilStatus, LotoFacilViewModelStatus>().ReverseMap();
        }
    }
}