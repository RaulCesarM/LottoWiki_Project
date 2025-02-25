using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryCorrelation : ILotoFacilQueryCorrelation
    {
        private readonly ILotoFacilRepository _repository;
        private List<LotoFacil> LotoFacils { get; set; } = new List<LotoFacil>();
        private int[][] Correlations { get; set; } = new int[25][];

        public LotoFacilQueryCorrelation(ILotoFacilRepository repository)
        {
            _repository = repository;

            for (int i = 0; i < 25; i++)
            {
                Correlations[i] = new int[25];
            }
        }

        public int[][] PopulateArrayOfArrays(int range)
        {
            SetPeriod(range);
            Correlations.InvertArray();
            return Correlations;
        }

        public void SetPeriod(int range)
        {
            LotoFacils = _repository.GetInRangeAsync(range).Result;

            foreach (var loto in LotoFacils)
            {
                for (int i = 1; i <= 25; i++)
                {
                    GetMathTarget(loto, i);
                }
            }
        }

        public void GetMathTarget(LotoFacil item, int targetNumber)
        {
            bool targetFound = false;
            List<int> drawnNumbers = new List<int>();

            for (int i = 1; i <= 15; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Casa", i);
                var property = typeof(LotoFacil).GetProperty(propertyName);
                int drawnNumber = Convert.ToInt32(property.GetValue(item));
                drawnNumbers.Add(drawnNumber);

                if (drawnNumber == targetNumber)
                {
                    targetFound = true;
                }
            }

            if (targetFound)
            {
                foreach (int number in drawnNumbers)
                {
                    AddInCorelation(targetNumber, number);
                }
            }
        }

        private void AddInCorelation(int targetNumber, int number)
        {
            if (targetNumber != number) Correlations[targetNumber - 1][number - 1]++;
        }

        public int[][] SerializeAllCorrelations()
        {
            return Correlations;
        }

        public LotoFacilViewModelCorrelationFriends GetTopCorrelationsForTarget(int targetNumber)
        {
            SetPeriod(180);
            if (targetNumber < 1 || targetNumber > 25) throw new ArgumentOutOfRangeException(nameof(targetNumber), "alvo entre 1 e 25.");

            int[] correlationsForTarget = Correlations[targetNumber - 1];

            var topCorrelations = correlationsForTarget
                .Select((occurrences, index) => new { Number = index + 1, Occurrences = occurrences })
                .Where(pair => pair.Number != targetNumber)
                .OrderByDescending(pair => pair.Occurrences)
                .ThenBy(pair => pair.Number)
                .Take(5)
                .ToArray();

            var viewModel = new LotoFacilViewModelCorrelationFriends
            {
                Target = targetNumber
            };

            if (topCorrelations.Length > 0)
            {
                viewModel.FirstBiggest = topCorrelations[0].Number;
                viewModel.FirstBiggestValue = topCorrelations[0].Occurrences;
            }

            if (topCorrelations.Length > 1)
            {
                viewModel.SecondBiggest = topCorrelations[1].Number;
                viewModel.SecondBiggestValue = topCorrelations[1].Occurrences;
            }

            if (topCorrelations.Length > 2)
            {
                viewModel.ThirdBiggest = topCorrelations[2].Number;
                viewModel.ThirdBiggestValue = topCorrelations[2].Occurrences;
            }

            if (topCorrelations.Length > 3)
            {
                viewModel.FourthBiggest = topCorrelations[3].Number;
                viewModel.FourthBiggestValue = topCorrelations[3].Occurrences;
            }

            return viewModel;
        }

        public int GetMostCorrelatedNumber(int targetNumber)
        {
            SetPeriod(180);
            if (targetNumber < 1 || targetNumber > 25)
                throw new ArgumentOutOfRangeException(nameof(targetNumber), "O número deve estar entre 1 e 25.");

            int maxCorrelation = 0;
            int mostCorrelatedNumber = -1;

            for (int i = 0; i < 25; i++)
            {
                if (i != targetNumber - 1 && Correlations[targetNumber - 1][i] > maxCorrelation)
                {
                    maxCorrelation = Correlations[targetNumber - 1][i];
                    mostCorrelatedNumber = i + 1;
                }
            }

            return mostCorrelatedNumber;
        }

        public int GetLeastCorrelatedNumber(int targetNumber)
        {
            SetPeriod(180);
            if (targetNumber < 1 || targetNumber > 25)
                throw new ArgumentOutOfRangeException(nameof(targetNumber), "O número deve estar entre 1 e 25.");

            int minCorrelation = int.MaxValue;
            int leastCorrelatedNumber = -1;

            for (int i = 0; i < 25; i++)
            {
                int correlation = Correlations[targetNumber - 1][i];

                if (i != targetNumber - 1 && correlation < minCorrelation && correlation > 0)
                {
                    minCorrelation = correlation;
                    leastCorrelatedNumber = i + 1;
                }
            }

            return leastCorrelatedNumber;
        }
    }
}