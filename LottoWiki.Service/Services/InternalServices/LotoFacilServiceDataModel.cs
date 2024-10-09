using AutoMapper;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.MachineLearning;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Services.InternalServices
{
    public class LotoFacilServiceDataModel : ILotoFacilServiceDataModel
    {
        private readonly IMapper _mapper;
        private readonly ILotoFacilCommonRepositoryDataModel _repository;

        public LotoFacilServiceDataModel(ILotoFacilCommonRepositoryDataModel repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LotoFacilDataModelViewModel> GetById(int key)
        {
            return _mapper.Map<LotoFacilDataModelViewModel>(await _repository.GetById(key));
        }

        public async Task Insert(LotoFacilDataModelViewModel entity)
        {
            await _repository.Insert(_mapper.Map<LotoFacilDataModel>(entity));
        }

        public LotoFacilDataModelViewModel GetLast()
        {
            return _mapper.Map<LotoFacilDataModelViewModel>(_repository.GetLast());
        }
    }
}