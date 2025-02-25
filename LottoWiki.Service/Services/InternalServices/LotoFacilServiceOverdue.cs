using AutoMapper;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;
using Microsoft.ML.AutoML;

namespace LottoWiki.Service.Services.InternalServices
{
    public class LotoFacilServiceOverdue : ILotoFacilServiceOverdue
    {
        private readonly IMapper _mapper;
        private readonly ILotoFacilRepositoryOverdue _repository;

        public LotoFacilServiceOverdue(ILotoFacilRepositoryOverdue repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public LotoFacilViewModelOverdue GetById(int key)
        {
            return _mapper.Map<LotoFacilViewModelOverdue>(_repository.GetById(key));
        }

        public LotoFacilViewModelOverdue GetLast()
        {
            return _mapper.Map<LotoFacilViewModelOverdue>(_repository.GetLast());
        }

        public int GetLastId()
        {
            return _mapper.Map<LotoFacilViewModelOverdue>(_repository.GetLast()).Concurso;
        }

        public int GetNextId()
        {
            return _mapper.Map<LotoFacilOverdue>(_repository.GetLast()).ProximoConcurso;
        }

        public int GetPreviusId()
        {
            return _mapper.Map<LotoFacilOverdue>(_repository.GetLast()).ConcursoAnterior;
        }

        public async Task Insert(LotoFacilViewModelOverdue entity)
        {
            await _repository.Insert(_mapper.Map<LotoFacilOverdue>(entity));
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