using AutoMapper;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.InternalServices
{
    public class LotoFacilService : ILotoFacilService
    {
        private readonly ILotoFacilRepository _repository;
        private readonly IMapper _mapper;

        public LotoFacilService(ILotoFacilRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Insert(LotoFacilViewModel entity)
        {
            await _repository.Insert(_mapper.Map<LotoFacil>(entity));
        }

        public LotoFacilViewModel GetById(int key)
        {
            return _mapper.Map<LotoFacilViewModel>(_repository.GetById(key));
        }

        public LotoFacilViewModel GetLast()
        {
            return _mapper.Map<LotoFacilViewModel>(_repository.GetLast());
        }

        public int GetLastId()
        {
            return _mapper.Map<LotoFacilViewModel>(_repository.GetLast()).Concurso;
        }

        public int GetNextId()
        {
            return _mapper.Map<LotoFacilViewModel>(_repository.GetLast()).ProximoConcurso;
        }

        public int GetPreviusId()
        {
            return _mapper.Map<LotoFacilViewModel>(_repository.GetLast()).ConcursoAnterior;
        }

        public async Task<int> CountOccurrencesInRangeAsync(int ball, int range)
        {
            var cocurrences = await _repository.CountOccurrencesInRange(ball, range);
            return cocurrences;
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}