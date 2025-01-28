using AutoMapper;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.InternalServices
{
    public class LotoFacilServiceStatus : ILotoFacilServiceStatus
    {
        private readonly IMapper _mapper;
        private readonly ILotoFacilRepositoryStatus _repository;

        public LotoFacilServiceStatus(ILotoFacilRepositoryStatus repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public LotoFacilViewModelStatus GetById(int key)
        {
            return _mapper.Map<LotoFacilViewModelStatus>(_repository.GetById(key));
        }

        public LotoFacilViewModelStatus GetLast()
        {
            return _mapper.Map<LotoFacilViewModelStatus>(_repository.GetLast());
        }

        public int GetLastId()
        {
            return _mapper.Map<LotoFacilViewModelStatus>(_repository.GetLast()).Concurso;
        }

        public int GetNextId()
        {
            return _mapper.Map<LotoFacilViewModelStatus>(_repository.GetLast()).ProximoConcurso;
        }

        public int GetPreviusId()
        {
            return _mapper.Map<LotoFacilViewModelStatus>(_repository.GetLast()).ConcursoAnterior;
        }

        public async Task Insert(LotoFacilViewModelStatus entity)
        {
            await _repository.Insert(_mapper.Map<LotoFacilStatus>(entity));
        }
    }
}