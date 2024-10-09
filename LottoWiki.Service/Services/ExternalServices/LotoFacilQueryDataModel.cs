using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;
using LottoWiki.Service.ViewModels.MachineLearning;
using System.Text;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LotoFacilQueryDataModel : ILotoFacilQueryDataModel
    {
        private readonly ILotoFacilCommonRepositoryStatus _status;
        private readonly ILotoFacilQueryCorrelation _correlation;

        public LotoFacilQueryDataModel(ILotoFacilCommonRepositoryStatus status, ILotoFacilQueryCorrelation correlation, ILotoFacilServiceDataModel service)
        {
            _status = status;
            _correlation = correlation;
        }

        public async Task<LotoFacilDataModelViewModel> CreateDataModel(int id, int ball)
        {
            var dataModel = new LotoFacilDataModelViewModel();
            dataModel.StatusId = id;
            dataModel.HorizontalSequence = await _status.GetEntityListAsString(id);
            id -= 10;
            List<LotoFacilStatus> statuses = GetStatusList(id);
            CreateVerticalSequence(statuses, ball, dataModel);

            return dataModel;
        }

        private List<LotoFacilStatus> GetStatusList(int id)
        {
            List<LotoFacilStatus> statuses = new List<LotoFacilStatus>(10);

            for (int i = 0; i <= 10; i++)
            {
                var status = _status.GetById(id + i);
                if (status == null) break;
                statuses.Add(status);
            }

            return statuses;
        }

        private void CreateVerticalSequence(List<LotoFacilStatus> statuses, int ball, LotoFacilDataModelViewModel dataModel)
        {
            var statusValues = new StringBuilder();
            var numeredSequence = new StringBuilder();
            var threeSequence = new StringBuilder();
            int rLetterCount = 0;
            int nLetterCount = 0;
            int aLetterCount = 0;
            int currentCount = 0;
            char previousChar = '\0';

            for (int i = 0; i < statuses.Count; i++)
            {
                string propertyName = BallNameFormatter.FormatBallName("Bola", ball);
                var property = typeof(LotoFacilStatus).GetProperty(propertyName);
                var value = property.GetValue(statuses[i]);
                char charValue = value.ToString()[0];

                if (i < 9)
                {
                    currentCount = (charValue == previousChar) ? currentCount + 1 : 1;
                    numeredSequence.Append($"{charValue}{currentCount}");
                    previousChar = charValue;
                    statusValues.Append(charValue);

                    _ = charValue switch
                    {
                        'A' => aLetterCount++,
                        'N' => nLetterCount++,
                        'R' => rLetterCount++,
                        _ => 0
                    };
                }

                if (i >= 6 && i <= 8)
                {
                    var charOption = charValue.ToString();
                    threeSequence.Append(charOption);
                }

                if (i == 8)
                {
                    PopulateNextOption(dataModel, charValue);
                }

                if (i == 9) dataModel.NextLetter = charValue.ToString();
            }
            dataModel.ThreeSequence = threeSequence.ToString();
            dataModel.LuckyBall = ball;
            PopulateFriendCorrelations(dataModel);
            PopulateCountLetter(dataModel, rLetterCount, nLetterCount, aLetterCount);
            PopulateSequencesStrings(dataModel, statusValues, numeredSequence);
        }

        private static void PopulateNextOption(LotoFacilDataModelViewModel dataModel, char charValue)
        {
            var charOption = charValue.ToString();
            if (charOption == "A")
            {
                dataModel.FirstOption = "A";
                dataModel.SecondOption = "N";
            }

            if (charOption == "N")
            {
                dataModel.FirstOption = "A";
                dataModel.SecondOption = "R";
            }
            if (charOption == "R")
            {
                dataModel.FirstOption = "A";
                dataModel.SecondOption = "R";
            }
        }

        private static void PopulateSequencesStrings(LotoFacilDataModelViewModel dataModel, StringBuilder statusValues, StringBuilder numeredSequence)
        {
            dataModel.NumeredSequence = numeredSequence.ToString();
            dataModel.VerticalSequence = statusValues.ToString();
        }

        private static void PopulateCountLetter(LotoFacilDataModelViewModel dataModel, int rLetterCount, int nLetterCount, int aLetterCount)
        {
            dataModel.NLetterCount = nLetterCount;
            dataModel.RLetterCount = rLetterCount;
            dataModel.ALetterCount = aLetterCount;
        }

        private void PopulateFriendCorrelations(LotoFacilDataModelViewModel dataModel)
        {
            LotoFacilViewModelCorrelationPlaces friend = _correlation.GetTopCorrelationsForTarget(dataModel.LuckyBall);
            dataModel.FirstFriend = friend.FirstBiggest;
            dataModel.SecondFriend = friend.SecondBiggest;
            dataModel.ThirdFriend = friend.ThirdBiggest;
        }
    }
}