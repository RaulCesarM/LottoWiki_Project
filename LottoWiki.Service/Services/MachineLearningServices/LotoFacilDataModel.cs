using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.MachineLearningServices
{
    public class LotoFacilDataModel
    {
        private readonly ILotoFacilRepositoryStatus _statusRepository;

        private readonly ILotoFacilRepositoryOverdue _overdueRepository;

        private readonly ILotoFacilRepositoryDoOver _dooverRepository;

        private readonly ILotoFacilQueryOcurrences _ocurrencesRepository;

        private readonly ILotoFacilRepository _lotofacilRepository;

        private LotoFacilViewModelDataModel dataModel { get; set; }
        private LotoFacilDoOver doOver { get; set; }
        private LotoFacilOverdue overdue { get; set; }
        private LotoFacilStatus status { get; set; }
        private LotoFacil lotoFacil { get; set; }

        private List<LotoFacilViewModelDataModel> dataModels { get; set; } = [];

        private int lastLotoFacilId;

        private int initialIterator = 1000;

        public LotoFacilDataModel(
            ILotoFacilRepositoryStatus statusRepository,
            ILotoFacilRepositoryOverdue overdueRepository,
            ILotoFacilRepositoryDoOver dooverRepository,
            ILotoFacilQueryOcurrences ocurrencesRepository,
            ILotoFacilRepository lotofacilRepository)
        {
            _statusRepository = statusRepository;
            _overdueRepository = overdueRepository;
            _dooverRepository = dooverRepository;
            _ocurrencesRepository = ocurrencesRepository;
            _lotofacilRepository = lotofacilRepository;
        }

        public void initializeServices()
        {
            lotoFacil = _lotofacilRepository.GetLast();

            for (int i = initialIterator; i <= lotoFacil.Concurso; i++)
            {
                doOver = _dooverRepository.GetById(i);
                overdue = _overdueRepository.GetById(i);
                status = _statusRepository.GetById(i);
            }
        }

        public void populateDataModel()
        {
        }
    }
}