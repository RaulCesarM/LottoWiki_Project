using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.ViewModels.Bases;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Domain.Models.Base;
using AutoMapper;

namespace LottoWiki.Service.Configurations
{
    public class LotoFacilConfigurationsProfile : Profile
    {
        public LotoFacilConfigurationsProfile()
        {
            CreateMap<LotoFacil, LotoFacilViewModel>().ReverseMap();
            CreateMap<LotoFacilHead, LotoFacilViewModelHead>().ReverseMap();
            CreateMap<LotoFacilDoOver, LotoFacilViewModelDoOver>().ReverseMap();
            CreateMap<LotoFacilOverdue, LotoFacilViewModelOverdue>().ReverseMap();
            CreateMap<LotoFacilStatus, LotoFacilViewModelStatus>().ReverseMap();
        }
    }
}