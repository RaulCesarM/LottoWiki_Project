using LottoWiki.Service.Interfaces.MachineLearning;
using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Domain.Models.Entities;
using System.Text;
using System.Globalization;
using Azure;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.MachineLearningServices
{
    public class LotoFacilDataModelService : ILotoFacilDataModelService
    {
        private readonly ILotoFacilRepositoryStatus _statusRepository;

        private readonly ILotoFacilRepositoryOverdue _overdueRepository;

        private readonly ILotoFacilRepositoryDoOver _dooverRepository;

        private readonly ILotoFacilQueryOcurrences _ocurrencesRepository;

        private readonly ILotoFacilRepository _lotofacilRepository;

        private List<LotoFacilViewModelDataModel> dataModels { get; set; } = [];

        private int LastLotoFacilId;

        private readonly int InitialIterator = 1000;

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
            var lastLotoFacil = _lotofacilRepository.GetLast();

            // for (int concurso = InitialIterator; concurso <= lastLotoFacil.Concurso; concurso++)
            for (int concurso = InitialIterator; concurso <= 1100; concurso++)
            {
                var lotoFacil = _lotofacilRepository.GetById(concurso);

                var doOver = _dooverRepository.GetById(concurso);
                var overdue = _overdueRepository.GetById(concurso);
                var status = _statusRepository.GetById(concurso);

                for (int numero = 1; numero <= 25; numero++)
                {
                    string ball = BallNameFormatter.FormatBallName("Bola", numero);
                    var property = typeof(LotoFacilOverdue).GetProperty(ball);
                    int overdueValue = Convert.ToInt32(property.GetValue(overdue));
                    int doOverValue = Convert.ToInt32(property.GetValue(doOver));
                    char statusValue = (char)(property.GetValue(status));

                    LotoFacilViewModelDataModel dataModel = new LotoFacilViewModelDataModel();
                    HeadDataModel(concurso, numero, dataModel);
                    PopulateFrequencies(InitialIterator, numero, dataModel);
                    CalculateRequiredContests(InitialIterator, numero, dataModel);
                    PopulateStardardDeviant(doOver.DesvioPadraoConcurso, doOver.DesvioPadraoGlobal, overdue.DesvioPadraoGlobal, overdue.DesvioPadraoConcurso, dataModel);
                    PopulateMeans(doOver.MediaConcurso, doOver.MediaGlobal, overdue.MediaConcurso, overdue.MediaGlobal, dataModel);
                    populateMacroStates(lotoFacil.Macro_Estado, doOver.Macro_Estado, overdue.Macro_Estado, dataModel);
                    PopulateDataModels(dataModel);
                    Consecutives(overdueValue, doOverValue, dataModel);
                    PopulateStatus(statusValue, dataModel);
                }
            }
        }

        private void PopulateStatus(char statusValue, LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Status = statusValue switch
            {
                'A' => 1,
                'R' => 2,
                'N' => 3
            };
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

        public static void PopulateStardardDeviant(
            double repeticao_Desvio_Padrao_Linha,
            double repeticao_Desvio_Padrao_Global,
            double atraso_Desvio_Padrao_Global,
            double atraso_Desvio_Padrao_Linha,
            LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Desvio_Padrao_Atraso_Global = atraso_Desvio_Padrao_Global;
            dataModel.Desvio_Padrao_Repeticao_Global = repeticao_Desvio_Padrao_Global;
            dataModel.Desvio_Padrao_Atraso_Por_Linha = atraso_Desvio_Padrao_Linha;
            dataModel.Desvio_Padrao_Repeticao_Por_Linha = repeticao_Desvio_Padrao_Linha;
        }

        public static void PopulateMeans(
            double repeticao_Media_Concurso,
            double repeticao_Media_Global,
            double atraso_Media_Concurso,
            double atraso_Media_Global,
            LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Media_Atraso_Por_Linha = atraso_Media_Concurso;
            dataModel.Media_Atraso_Global = atraso_Media_Global;
            dataModel.Media_Repeticao_Por_Linha = repeticao_Media_Concurso;
            dataModel.Media_Repeticao_Global = repeticao_Media_Global;
        }

        private static void populateMacroStates(
            int macro_Estado_Principal,
            int macro_Estado_Repeticao,
            int macro_Estado_atraso,
            LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Macro_Estado_Principal = macro_Estado_Principal;
            dataModel.Macro_Estado_Repeticao = macro_Estado_Repeticao;
            dataModel.Macro_Estado_Atraso = macro_Estado_atraso;
        }

        private static void Consecutives(int overdueValue, int doOverValue, LotoFacilViewModelDataModel dataModel)
        {
            dataModel.Atraso_Consecutivo = overdueValue;
            dataModel.Repeticao_Consecutiva = doOverValue;
        }

        public void PopulateDataModels(LotoFacilViewModelDataModel dataModel)
        {
            dataModels.Add(dataModel);
        }

        public void CreateCsv(string filePath)
        {
            initializeServices();
            var csvLines = new List<string>();
            csvLines.Add("Concurso_Referencia,Numero,Frequencia_Fracionada_de_005,Frequencia_Fracionada_de_010,Frequencia_Fracionada_de_015,Frequencia_Fracionada_de_025,Frequencia_Fracionada_de_040,Frequencia_Fracionada_de_065,Frequencia_Fracionada_de_105,Concursos_Necessarios_005_aparicoes,Concursos_Necessarios_010_aparicoes,Concursos_Necessarios_015_aparicoes,Concursos_Necessarios_025_aparicoes,Concursos_Necessarios_040_aparicoes,Concursos_Necessarios_065_aparicoes,Concursos_Necessarios_105_aparicoes,Atraso_Consecutivo,Repeticao_Consecutiva,Media_Repeticao_Por_Linha,Media_Repeticao_Global,Media_Atraso_Por_Linha,Media_Atraso_Global,Desvio_Padrao_Repeticao_Por_Linha,Desvio_Padrao_Repeticao_Global,Desvio_Padrao_Atraso_Por_Linha,Desvio_Padrao_Atraso_Global,Macro_Estado_Principal,Macro_Estado_Repeticao,Macro_Estado_Atraso,Maior_Atraso,Maior_Repeticao,Par_Correlato,Par_Divergente,Status");

            foreach (var item in dataModels)
            {
                csvLines.Add($"{item.Concurso_Referencia},{item.Numero}," +
                    $"{item.Frequencia_Fracionada_de_005.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_010.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_015.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_025.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_040.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_065.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Frequencia_Fracionada_de_105.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Concursos_Nescessarios_005_aparicoes}," +
                    $"{item.Concursos_Nescessarios_010_aparicoes}," +
                    $"{item.Concursos_Nescessarios_015_aparicoes}," +
                    $"{item.Concursos_Nescessarios_025_aparicoes}," +
                    $"{item.Concursos_Nescessarios_040_aparicoes}," +
                    $"{item.Concursos_Nescessarios_065_aparicoes}," +
                    $"{item.Concursos_Nescessarios_105_aparicoes}," +
                    $"{item.Atraso_Consecutivo}," +
                    $"{item.Repeticao_Consecutiva}," +
                    $"{item.Media_Repeticao_Por_Linha.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Media_Repeticao_Global.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Media_Atraso_Por_Linha.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Media_Atraso_Global.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Desvio_Padrao_Repeticao_Por_Linha.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Desvio_Padrao_Repeticao_Global.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Desvio_Padrao_Atraso_Por_Linha.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Desvio_Padrao_Atraso_Global.ToString(CultureInfo.InvariantCulture)}," +
                    $"{item.Macro_Estado_Principal}," +
                    $"{item.Macro_Estado_Repeticao}," +
                    $"{item.Macro_Estado_Atraso}," +
                    $"{item.Maior_Atraso}," +
                    $"{item.Maior_Repeticao}," +
                    $"{item.Par_Correlato}," +
                    $"{item.Par_Divergente}," +
                    $"{item.Status}");
            }

            File.WriteAllLines(filePath, csvLines, Encoding.UTF8);
        }
    }
}