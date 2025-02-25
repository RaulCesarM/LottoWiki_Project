using AutoMapper;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.InternalServices
{
    public class LotoFacilServiceDoOver : ILotoFacilServiceDoOver
    {
        private readonly IMapper _mapper;
        private readonly ILotoFacilRepositoryDoOver _repository;

        public LotoFacilServiceDoOver(ILotoFacilRepositoryDoOver repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public LotoFacilViewModelDoOver GetById(int key)
        {
            return _mapper.Map<LotoFacilViewModelDoOver>(_repository.GetById(key));
        }

        public LotoFacilViewModelDoOver GetLast()
        {
            return _mapper.Map<LotoFacilViewModelDoOver>(_repository.GetLast());
        }

        public int GetLastId()
        {
            return _mapper.Map<LotoFacilViewModelDoOver>(_repository.GetLast()).Concurso;
        }

        public int GetNextId()
        {
            return _mapper.Map<LotoFacilDoOver>(_repository.GetLast()).ProximoConcurso;
        }

        public int GetPreviusId()
        {
            return _mapper.Map<LotoFacilViewModelDoOver>(_repository.GetLast()).ConcursoAnterior;
        }

        public async Task Insert(LotoFacilViewModelDoOver entity)
        {
            await _repository.Insert(_mapper.Map<LotoFacilDoOver>(entity));
        }

        public double GetGlobalStandardDeviation()
        {
            List<int> result = _repository.GetGlobalStandardDeviation().Result;
            return result.CalcularDesvioPadrao();
        }

        public double GetGlobalMeans()
        {
            List<int> result = _repository.GetGlobalMeans().Result;
            if (result == null || result.Count == 0)
                throw new ArgumentException("A lista de valores não pode estar vazia.");

            return result.Average();
        }
    }
}