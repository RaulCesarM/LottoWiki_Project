using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.ViewModels.Bases;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Domain.Models.Base;
using AutoMapper;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapper : Profile
    {
        public LotoFacilAutoMapper()
        {
            CreateMap<LotoFacil, LotoFacilViewModel>().ReverseMap();
            CreateMap<LotoFacilHead, LotoFacilHeadViewModel>().ReverseMap();
        }
    }
}