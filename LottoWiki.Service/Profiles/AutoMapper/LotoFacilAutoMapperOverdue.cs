using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Domain.Models.Entities;
using AutoMapper;

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