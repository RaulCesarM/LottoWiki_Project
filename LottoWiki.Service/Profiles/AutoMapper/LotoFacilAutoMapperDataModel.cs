using AutoMapper;
using LottoWiki.Domain.Models.MachineLearning;
using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Profiles.AutoMapper
{
    public class LotoFacilAutoMapperDataModel : Profile
    {
        public LotoFacilAutoMapperDataModel()
        {
            CreateMap<LotoFacilDataModel, LotoFacilDataModelViewModel>().ReverseMap();
        }
    }
}