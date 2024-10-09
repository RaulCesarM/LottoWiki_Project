using AutoMapper;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapperOverdue : Profile
    {
        public LotoFacilAutoMapperOverdue()
        {
            CreateMap<LotoFacilOverdue, LotoFacilViewModelOverdue>().ReverseMap();
        }
    }
}