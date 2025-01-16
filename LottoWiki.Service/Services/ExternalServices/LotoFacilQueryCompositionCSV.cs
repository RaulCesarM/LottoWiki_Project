using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.Utils;
using System.Text;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Domain.Models.Entities;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryCompositionCSV : ILotoFacilQueryCompositionCSV
    {
        private readonly ILotoFacilCommonRepositoryOverdue _overdueRepository;
        private readonly ILotoFacilCommonRepositoryDoOver _dooverRepository;
        private readonly ILotoFacilCommonRepositoryStatus _statusRepository;

        public LotoFacilQueryCompositionCSV(
            ILotoFacilCommonRepositoryOverdue overdueRepository,
            ILotoFacilCommonRepositoryDoOver dooverRepository,
            ILotoFacilCommonRepositoryStatus statusRepository)
        {
            _overdueRepository = overdueRepository;
            _dooverRepository = dooverRepository;
            _statusRepository = statusRepository;
        }

        public void CreateCsv(string filePath)
        {
            var csvLines = new List<string>
            {
                "NumeroSorteado,Atraso,Repeticao,Status"
            };

            for (int i = 500; i < 3300; i++)
            {
                var overDue = _overdueRepository.GetById(i);
                var doover = _dooverRepository.GetById(i);
                var status = _statusRepository.GetById(i + 1);

                if (overDue == null || doover == null || status == null)
                {
                    continue;
                }

                for (int j = 1; j <= 25; j++)
                {
                    var stats = CreateStats(j, overDue, doover, status);

                    int statusInEncoder;
                    if (stats.status == 'N')
                    {
                        statusInEncoder = 1;
                    }
                    else if (stats.status == 'R')
                    {
                        statusInEncoder = 2;
                    }
                    else
                    {
                        statusInEncoder = 0;
                    }

                    csvLines.Add($"{stats.NumeroSorteado},{stats.Atraso},{stats.Repeticao},{statusInEncoder}");
                }
            }

            File.WriteAllLines(filePath, csvLines, Encoding.UTF8);
        }

        private LotoFacilStatsViewModel CreateStats(
            int ballNumber,
            LotoFacilOverdue overDue,
            LotoFacilDoOver doover,
            LotoFacilStatus status)
        {
            var stats = new LotoFacilStatsViewModel();
            string propertyName = BallNameFormatter.FormatBallName("Bola", ballNumber);

            stats.NumeroSorteado = ballNumber;
            stats.Atraso = GetPropertyValue<int>(overDue, propertyName);
            stats.Repeticao = GetPropertyValue<int>(doover, propertyName);
            stats.status = GetPropertyValue<char>(status, propertyName);

            return stats;
        }

        private T GetPropertyValue<T>(object instance, string propertyName)
        {
            var property = instance.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Propriedade '{propertyName}' não encontrada na classe '{instance.GetType().Name}'.");
            }

            var value = property.GetValue(instance);
            if (value is T typedValue)
            {
                return typedValue;
            }

            throw new InvalidCastException($"Propriedade '{propertyName}' não pode ser convertida para o tipo {typeof(T).Name}.");
        }
    }
}