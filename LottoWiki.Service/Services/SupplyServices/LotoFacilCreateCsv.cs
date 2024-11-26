//using LottoWiki.Domain.Interfaces.IRepository;
//using LottoWiki.Domain.Models.Entities;
//using LottoWiki.Service.Interfaces.External;
//using LottoWiki.Service.Interfaces.Internal;
//using LottoWiki.Service.Interfaces.Supply;
//using LottoWiki.Service.Utils;
//using LottoWiki.Service.ViewModels.Entities;
//using Microsoft.Extensions.Logging;
//using System.Text;

//namespace LottoWiki.Service.Services.SupplyServices
//{
//    public class LotoFacilSupplyDataModel : ILotoFacilSupplyDataModel
//    {
//        private readonly ILotoFacilQueryCorrelation _correlation;
//        private readonly ILogger<LotoFacilSupplyDataModel> _logger;
//        private readonly ILotoFacilServiceDataModel _service;
//        private readonly ILotoFacilCommonRepositoryStatus _status;

//        public LotoFacilSupplyDataModel(ILotoFacilCommonRepositoryStatus status, ILotoFacilQueryCorrelation correlation, ILotoFacilServiceDataModel service, ILogger<LotoFacilSupplyDataModel> logger)
//        {
//            _status = status;
//            _correlation = correlation;
//            _service = service;
//            _logger = logger;
//        }

//        public async Task<int> CreateDataModel(int id, int ball)
//        {
//            try
//            {
//                dataModel.StatusId = id;
//                dataModel.HorizontalSequence = await _status.GetEntityListAsString(id);

//                List<LotoFacilStatus> statuses = GetStatusList(id);
//                CreateVerticalSequence(statuses, ball, dataModel);
//                await SaveDataModel(dataModel);
//                return 1;
//            }
//            catch (Exception ex)
//            {
//                var msg = $"DataModel não foi criado / causa {ex.Message}";
//                _logger.LogMethodInfo(msg);
//                return 0;
//            }
//        }

//        public bool HasNext()
//        {
//            int id = 10;

//            //while (id < 3170)
//            //{
//            //    if (_status.Exists(id) && _status.GetById(id + 10) != null)
//            //    {
//            //        int incrise = 0;
//            //        int incriseId = 0;
//            //        for (int ball = 1; ball <= 25; ball++)
//            //        {
//            //            incrise += CreateDataModel(id, ball).Result;
//            //            incriseId = (ball / incrise);
//            //        }
//            //        id += incriseId;
//            //    }
//            //}

//            return false;
//        }

//        public async Task SaveDataModel(LotoFacilDataModelViewModel dataModel)
//        {
//            try
//            {
//                await _service.Insert(dataModel);
//            }
//            catch (Exception ex)
//            {
//                var msg = $"DataModel não foi salva / causa {ex.Message}";
//                _logger.LogMethodInfo(msg);
//            }
//        }

//        private void CreateVerticalSequence(List<LotoFacilStatus> statuses, int ball, LotoFacilDataModelViewModel dataModel)
//        {
//            var statusValues = new StringBuilder();
//            var numeredSequence = new StringBuilder();
//            var threeSequence = new StringBuilder();
//            int rLetterCount = 0;
//            int nLetterCount = 0;
//            int aLetterCount = 0;
//            int currentCount = 0;
//            char previousChar = '\0';

//            for (int i = 0; i < statuses.Count; i++)
//            {
//                string propertyName = BallNameFormatter.FormatBallName("Bola", ball);
//                var property = typeof(LotoFacilStatus).GetProperty(propertyName);
//                var value = property.GetValue(statuses[i]);
//                char charValue = value.ToString()[0];

//                if (i < 9)
//                {
//                    currentCount = (charValue == previousChar) ? currentCount + 1 : 1;
//                    numeredSequence.Append($"{charValue}{currentCount}");
//                    previousChar = charValue;
//                    statusValues.Append(charValue);

//                    _ = charValue switch
//                    {
//                        'A' => aLetterCount++,
//                        'N' => nLetterCount++,
//                        'R' => rLetterCount++,
//                        _ => 0
//                    };
//                }

//                if (i >= 6 && i <= 8)
//                {
//                    var charOption = charValue.ToString();
//                    threeSequence.Append(charOption);
//                }

//                if (i == 8)
//                {
//                    PopulateNextOption(dataModel, charValue);
//                }

//                if (i == 9) dataModel.NextLetter = charValue.ToString();
//            }
//            dataModel.ThreeSequence = threeSequence.ToString();
//            dataModel.LuckyBall = ball;
//            CheckSuggestion(dataModel);
//            PopulateSugestion(dataModel);
//            PopulateFriendCorrelations(dataModel);
//            PopulateCountLetter(dataModel, rLetterCount, nLetterCount, aLetterCount);
//            PopulateSequencesStrings(dataModel, statusValues, numeredSequence);
//        }

//        private static void CheckSuggestion(LotoFacilDataModelViewModel dataModel)
//        {
//            if (dataModel == null) return;
//            if (dataModel.NextLetter == dataModel.NextLetterSugestion)
//            {
//                dataModel.ValidNextLetterSugestion = "T";
//            }
//            else
//            {
//                dataModel.ValidNextLetterSugestion = "F";
//            }
//        }

//        private void PopulateSugestion(LotoFacilDataModelViewModel dataModel)
//        {
//            dataModel.NextLetterSugestion = _lightGbmPreview.PredictLetter(dataModel.ThreeSequence);
//        }

//        private List<LotoFacilStatus> GetStatusList(int id)
//        {
//            List<LotoFacilStatus> statuses = new List<LotoFacilStatus>(10);

//            for (int i = 0; i < 10; i++)
//            {
//                var status = _status.GetById(id + i);
//                if (status == null) break;
//                statuses.Add(status);
//            }

//            return statuses;
//        }

//        private static void PopulateCountLetter(LotoFacilDataModelViewModel dataModel, int rLetterCount, int nLetterCount, int aLetterCount)
//        {
//            dataModel.NLetterCount = nLetterCount;
//            dataModel.RLetterCount = rLetterCount;
//            dataModel.ALetterCount = aLetterCount;
//        }

//        private void PopulateFriendCorrelations(LotoFacilDataModelViewModel dataModel)
//        {
//            LotoFacilViewModelCorrelationPlaces friend = _correlation.GetTopCorrelationsForTarget(dataModel.LuckyBall);
//            dataModel.FirstFriend = friend.FirstBiggest;
//            dataModel.SecondFriend = friend.SecondBiggest;
//            dataModel.ThirdFriend = friend.ThirdBiggest;

//            dataModel.FirstFriendLetter = dataModel.HorizontalSequence[dataModel.FirstFriend].ToString();
//            dataModel.SecondFriendLetter = dataModel.HorizontalSequence[dataModel.SecondFriend].ToString();
//            dataModel.ThirdFriendLetter = dataModel.HorizontalSequence[dataModel.ThirdFriend].ToString();
//        }

//        private static void PopulateNextOption(LotoFacilDataModelViewModel dataModel, char charValue)
//        {
//            var charOption = charValue.ToString();
//            if (charOption == "A")
//            {
//                dataModel.NextNumber = 0;
//                if (dataModel.ALetterCount > dataModel.NLetterCount)
//                {
//                    dataModel.FirstOption = "A";
//                    dataModel.SecondOption = "N";
//                }
//                else
//                {
//                    dataModel.FirstOption = "N";
//                    dataModel.SecondOption = "A";
//                }
//            }

//            if (charOption == "N")
//            {
//                dataModel.NextNumber = 1;
//                if (dataModel.ALetterCount > dataModel.RLetterCount)
//                {
//                    dataModel.FirstOption = "A";
//                    dataModel.SecondOption = "R";
//                }
//                else
//                {
//                    dataModel.FirstOption = "R";
//                    dataModel.SecondOption = "A";
//                }
//            }
//            if (charOption == "R")
//            {
//                dataModel.NextNumber = 1;
//                if (dataModel.ALetterCount > dataModel.RLetterCount)
//                {
//                    dataModel.FirstOption = "A";
//                    dataModel.SecondOption = "R";
//                }
//                else
//                {
//                    dataModel.FirstOption = "R";
//                    dataModel.SecondOption = "A";
//                }
//            }
//        }

//        private static void PopulateSequencesStrings(LotoFacilDataModelViewModel dataModel, StringBuilder statusValues, StringBuilder numeredSequence)
//        {
//            dataModel.NumeredSequence = numeredSequence.ToString();
//            dataModel.VerticalSequence = statusValues.ToString();
//        }
//    }
//}