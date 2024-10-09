using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Interfaces.MachineLearning.Training;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.MachineLearning;

namespace LottoWiki.Service.Services.MachineLearning
{
    public class DataConverter : IDataConverter
    {
        private readonly ILotoFacilServiceDataModel _baseDta;
        private List<LottoFacilLightGbm> LightGbms { get; set; } = [];

        private List<LotoFacilLbfgsMaximumEntropy> LotoFacilLbfgsMaximumEntropys { get; set; } = [];
        private List<LotoFacilLbfgsLogisticRegression> LotoFacilLbfgsLogisticRegressions { get; set; } = [];

        public DataConverter(ILotoFacilServiceDataModel baseDta)
        {
            _baseDta = baseDta;
        }

        public async Task<List<LottoFacilLightGbm>> PopulateLightGbm()
        {
            int id = 1000;

            while (id < 10200)
            {
                if (await _baseDta.GetById(id) != null)
                {
                    LotoFacilDataModelViewModel dataModel = await _baseDta.GetById(id);
                    LottoFacilLightGbm lightGbm = dataModel.ConvertLightGbm();

                    LightGbms.Add(lightGbm);
                    id++;
                }
            }

            return LightGbms;
        }

        public async Task<List<LotoFacilLbfgsMaximumEntropy>> PopulateLbfgsMaximumEntropy()
        {
            int id = 1000;

            while (id < 10200)
            {
                if (await _baseDta.GetById(id) != null)
                {
                    LotoFacilDataModelViewModel dataModel = await _baseDta.GetById(id);
                    LotoFacilLbfgsMaximumEntropy lotoFacilLbfgsMaximumEntropy = dataModel.ConvertLbfgsMaximumEntropy();

                    LotoFacilLbfgsMaximumEntropys.Add(lotoFacilLbfgsMaximumEntropy);
                    id++;
                }
            }

            return LotoFacilLbfgsMaximumEntropys;
        }

        public async Task<List<LotoFacilLbfgsLogisticRegression>> PopulateLotoFacilLbfgsLogisticRegression()
        {
            int id = 1000;

            while (id < 10200)
            {
                if (await _baseDta.GetById(id) != null)
                {
                    LotoFacilDataModelViewModel dataModel = await _baseDta.GetById(id);
                    LotoFacilLbfgsLogisticRegression lotoFacilLbfgsLogisticRegression = dataModel.ConvertLbfgsLogisticRegression();

                    LotoFacilLbfgsLogisticRegressions.Add(lotoFacilLbfgsLogisticRegression);
                    id++;
                }
            }

            return LotoFacilLbfgsLogisticRegressions;
        }

        //public async Task<int> CreateCSV()
        //{
        //    int id = 10;
        //    string _modelPath = Path.Combine("MachineLearning", "data.csv");
        //    string directoryPath = Path.GetDirectoryName(_modelPath);

        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }

        //    using (StreamWriter writer = new(_modelPath))
        //    {
        //        StringBuilder headerBuilder = new();
        //        headerBuilder.Append("NextLetter,");
        //        headerBuilder.Append("Id,");
        //        headerBuilder.Append("StatusId,");
        //        headerBuilder.Append("LuckyBall,");
        //        headerBuilder.Append("FirstFriend,");
        //        headerBuilder.Append("SecondFriend,");
        //        headerBuilder.Append("ThirdFriend,");
        //        headerBuilder.Append("RLetterCount,");
        //        headerBuilder.Append("NLetterCount,");
        //        headerBuilder.Append("ALetterCount,");
        //        headerBuilder.Append("FirstOption,");
        //        headerBuilder.Append("SecondOption,");
        //        headerBuilder.Append("ThreeSequence,");
        //        headerBuilder.Append("NumeredSequence,");
        //        headerBuilder.Append("HorizontalSequence,");
        //        headerBuilder.Append("VerticalSequence");

        //        await writer.WriteLineAsync(headerBuilder.ToString());

        //        while (id < 30000)
        //        {
        //            LotoFacilDataModelViewModel dataModel = await _baseDta.GetById(id);
        //            if (dataModel != null)
        //            {
        //                StringBuilder bodyBuilder = new();
        //                bodyBuilder.AppendFormat("{0},", dataModel.NextLetter);
        //                bodyBuilder.AppendFormat("{0},", dataModel.Id);
        //                bodyBuilder.AppendFormat("{0},", dataModel.StatusId);
        //                bodyBuilder.AppendFormat("{0},", dataModel.LuckyBall);
        //                bodyBuilder.AppendFormat("{0},", dataModel.FirstFriend);
        //                bodyBuilder.AppendFormat("{0},", dataModel.SecondFriend);
        //                bodyBuilder.AppendFormat("{0},", dataModel.ThirdFriend);
        //                bodyBuilder.AppendFormat("{0},", dataModel.RLetterCount);
        //                bodyBuilder.AppendFormat("{0},", dataModel.NLetterCount);
        //                bodyBuilder.AppendFormat("{0},", dataModel.ALetterCount);
        //                bodyBuilder.AppendFormat("{0},", dataModel.FirstOption);
        //                bodyBuilder.AppendFormat("{0},", dataModel.SecondOption);
        //                bodyBuilder.AppendFormat("{0},", dataModel.ThreeSequence);
        //                bodyBuilder.AppendFormat("{0},", dataModel.NumeredSequence);
        //                bodyBuilder.AppendFormat("{0},", dataModel.HorizontalSequence);
        //                bodyBuilder.AppendFormat("{0}", dataModel.VerticalSequence);

        //                await writer.WriteLineAsync(bodyBuilder.ToString());
        //            }

        //            id++;
        //        }
        //    }

        //    return id;
        //}

        public async Task<int> CreateCSV()
        {
            int id = 10;
            Random random = new Random();

            string VerticalSequence = "";
            string ThreeSequence = "";
            string NextLetter = "";

            while (id < 30000)
            {
                if (VerticalSequence.Length == 9)
                {
                    NextLetter = GetNextLetter(random, ThreeSequence);
                    VerticalSequence = VerticalSequence[3..];
                    ThreeSequence = VerticalSequence[^3..];

                    LotoFacilDataModelViewModel dataModel = new()
                    {
                        NextLetter = NextLetter,
                        ThreeSequence = ThreeSequence,
                        VerticalSequence = VerticalSequence
                    };

                    await _baseDta.Insert(dataModel);
                }

                VerticalSequence += GetNextLetter(random, ThreeSequence);
                ThreeSequence = VerticalSequence.Length > 3 ? VerticalSequence[^3..] : VerticalSequence;

                id++;
            }

            return id;
        }

        private static string GetNextLetter(Random random, string ThreeSequence)
        {
            string NextLetter = "";

            if (ThreeSequence.Length == 3)
            {
                char lastLetter = ThreeSequence[^1];

                if (lastLetter == 'A')
                {
                    NextLetter = random.Next(0, 2) == 0 ? "A" : "N";
                }
                else if (lastLetter == 'N')
                {
                    NextLetter = random.Next(0, 2) == 0 ? "A" : "R";
                }
                else if (lastLetter == 'R')
                {
                    NextLetter = random.Next(0, 2) == 0 ? "A" : "R";
                }
            }
            else
            {
                NextLetter = random.Next(0, 3) switch
                {
                    0 => "R",
                    1 => "N",
                    2 => "A",
                    _ => "A"
                };
            }

            return NextLetter;
        }
    }
}