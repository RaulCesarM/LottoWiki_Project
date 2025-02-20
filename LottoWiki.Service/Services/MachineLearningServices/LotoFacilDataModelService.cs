using LottoWiki.Service.Interfaces.MachineLearning;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Service.Services.MachineLearningServices
{
    public class LotoFacilDataModelService : ILotoFacilDataModelService
    {
        private readonly ILotoFacilRepositoryStatus _statusRepository;

        private readonly ILotoFacilRepositoryOverdue _overdueRepository;

        private readonly ILotoFacilRepositoryDoOver _dooverRepository;

        private readonly ILotoFacilQueryOcurrences _ocurrencesRepository;

        private readonly ILotoFacilRepository _lotofacilRepository;

        private LotoFacilDoOver doOver { get; set; }

        private LotoFacilOverdue overdue { get; set; }
        private LotoFacilStatus status { get; set; }
        private LotoFacil lotoFacil { get; set; }

        private List<LotoFacilViewModelDataModel> dataModels { get; set; } = [];

        private int lastLotoFacilId;

        private int initialIterator = 1000;

        public LotoFacilDataModelService(
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
                LotoFacilViewModelDataModel dataModel = new LotoFacilViewModelDataModel();
                doOver = _dooverRepository.GetById(i);
                overdue = _overdueRepository.GetById(i);
                status = _statusRepository.GetById(i);

                for (int numero = 1; numero <= 25; numero++)
                {
                    HeadDataModel(initialIterator, numero, dataModel);
                    PopulateFrequencies(initialIterator, numero, dataModel);
                    CalculateRequiredContests(initialIterator, numero, dataModel);
                    CalculateMeans(initialIterator, numero, dataModel);
                }
            }
        }

        public static void HeadDataModel(int concurso, int numero, LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Concurso_Referencia = concurso;
            dataModel.Numero = numero;
        }

        public void PopulateFrequencies(int concurso, int numero, LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Frequencia_Fracionada_de_005 = _ocurrencesRepository.GetFrequency(numero, concurso, 5);
            dataModel.Frequencia_Fracionada_de_010 = _ocurrencesRepository.GetFrequency(numero, concurso, 10);
            dataModel.Frequencia_Fracionada_de_015 = _ocurrencesRepository.GetFrequency(numero, concurso, 15);
            dataModel.Frequencia_Fracionada_de_025 = _ocurrencesRepository.GetFrequency(numero, concurso, 25);
            dataModel.Frequencia_Fracionada_de_040 = _ocurrencesRepository.GetFrequency(numero, concurso, 40);
            dataModel.Frequencia_Fracionada_de_065 = _ocurrencesRepository.GetFrequency(numero, concurso, 65);
            dataModel.Frequencia_Fracionada_de_105 = _ocurrencesRepository.GetFrequency(numero, concurso, 105);
        }

        public void CalculateRequiredContests(int concurso, int numero, LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Concursos_Nescessarios_005_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 5);
            dataModel.Concursos_Nescessarios_010_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 10);
            dataModel.Concursos_Nescessarios_015_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 15);
            dataModel.Concursos_Nescessarios_025_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 25);
            dataModel.Concursos_Nescessarios_040_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 40);
            dataModel.Concursos_Nescessarios_065_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 65);
            dataModel.Concursos_Nescessarios_105_aparicoes = _ocurrencesRepository.GetRequiredContest(numero, concurso, 105);
        }

        public void CalculateMeans(int concurso, int numero, LotoFacilViewModelDataModel dataModel)
        {
        }

        public void PopulateDataModels(LotoFacilViewModelDataModel dataModel)
        {
            dataModels.Add(dataModel);
        }

        public void CreateCsv(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}