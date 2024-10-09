using AutoMapper;
using LottoWiki.Domain.Models.Base;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.ViewModels.Bases;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapper : Profile
    {
        public LotoFacilAutoMapper()
        {
            CreateMap<LotoFacil, LotoFacilViewModel>().ReverseMap();
            CreateMap<LotoFacilStats, LotoFacilStatsViewModel>().ReverseMap();
        }
    }
}