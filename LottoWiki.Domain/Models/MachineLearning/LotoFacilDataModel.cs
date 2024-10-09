namespace LottoWiki.Domain.Models.MachineLearning
{
    public class LotoFacilDataModel
    {
        // predictions

        public string NextLetter { get; set; }

        public int NextNumber { get; set; }

        public int LuckyBall { get; set; }

        // test

        public string ValidNextLetterSugestion { get; set; }
        public string TrueFriendLetter { get; set; }

        // refrences
        public int Id { get; set; }

        public int StatusId { get; set; }

        // correlations

        public string LunarSeasonality { get; set; }

        public int FirstFriend { get; set; }

        public int SecondFriend { get; set; }

        public int ThirdFriend { get; set; }

        public string FirstFriendLetter { get; set; }

        public string SecondFriendLetter { get; set; }

        public string ThirdFriendLetter { get; set; }

        // count

        public int RLetterCount { get; set; }

        public int NLetterCount { get; set; }

        public int ALetterCount { get; set; }

        // options
        public string NextLetterSugestion { get; set; }

        public string FirstOption { get; set; }

        public string SecondOption { get; set; }

        //sequences

        public string ThreeSequence { get; set; }

        public string NumeredSequence { get; set; }

        public string HorizontalSequence { get; set; }

        public string VerticalSequence { get; set; }

        public LotoFacilDataModel()
        {
        }
    }
}