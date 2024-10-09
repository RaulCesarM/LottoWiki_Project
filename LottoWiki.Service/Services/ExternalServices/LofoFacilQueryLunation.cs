using LottoWiki.Domain.Interfaces.IRepository;
using LottoWiki.Domain.Models.Entities;
using LottoWiki.Service.Interfaces.External;
using LottoWiki.Service.Utils;

namespace LottoWiki.Service.Services.ExternalServices
{
    public class LofoFacilQueryLunation : ILotoFacilQueryLunation
    {
        private readonly ILotoFacilCommonRepository _repository;

        private List<LotoFacil> LotoFacils { get; set; } = new List<LotoFacil>();

        private List<LotoFacil> Crescente { get; set; } = [];
        private List<LotoFacil> Nova { get; set; } = [];
        private List<LotoFacil> Minguante { get; set; } = [];
        private List<LotoFacil> Cheia { get; set; } = [];
        private List<LotoFacil> QuartoCrescente { get; set; } = [];
        private List<LotoFacil> GibosaCrescente { get; set; } = [];
        private List<LotoFacil> QuartoMinguante { get; set; } = [];
        private List<LotoFacil> GibosaMinguante { get; set; } = [];

        public LofoFacilQueryLunation(ILotoFacilCommonRepository repository)
        {
            _repository = repository;
            Init();
        }

        private void Init()
        {
            LotoFacils = _repository.GetInRangeAsync(200).Result;
            Crescente = LotoFacils.Where(lf => lf.LuaDoSorteio == "Crescente").ToList();
            Nova = LotoFacils.Where(lf => lf.LuaDoSorteio == "Nova").ToList();
            Minguante = LotoFacils.Where(lf => lf.LuaDoSorteio == "Minguante").ToList();
            Cheia = LotoFacils.Where(lf => lf.LuaDoSorteio == "Cheia").ToList();
            QuartoCrescente = LotoFacils.Where(lf => lf.LuaDoSorteio == "Quarto Crescente").ToList();
            GibosaCrescente = LotoFacils.Where(lf => lf.LuaDoSorteio == "Gibosa Crescente").ToList();
            QuartoMinguante = LotoFacils.Where(lf => lf.LuaDoSorteio == "Quarto Minguante").ToList();
            GibosaMinguante = LotoFacils.Where(lf => lf.LuaDoSorteio == "Gibosa Minguante").ToList();
        }

        private int[] CountDrawnNumbers(List<LotoFacil> lotoFacils)
        {
            int[] drawnNumbersCount = new int[26];

            foreach (var item in lotoFacils)
            {
                for (int i = 1; i <= 15; i++)
                {
                    string propertyName = BallNameFormatter.FormatBallName("Casa", i);
                    var property = typeof(LotoFacil).GetProperty(propertyName);
                    int drawnNumber = Convert.ToInt32(property.GetValue(item));
                    drawnNumbersCount[drawnNumber]++;
                }
            }

            return drawnNumbersCount.Skip(1).ToArray();
        }

        public int[] GetCrescentMoon()
        {
            return CountDrawnNumbers(Crescente);
        }

        public int[] GetFullMoon()
        {
            return CountDrawnNumbers(Cheia);
        }

        public int[] GetGibbousCrescentMoon()
        {
            return CountDrawnNumbers(GibosaCrescente);
        }

        public int[] GetGibbousWaningMoon()
        {
            return CountDrawnNumbers(GibosaMinguante);
        }

        public int[] GetNewMoon()
        {
            return CountDrawnNumbers(Nova);
        }

        public int[] GetQuarterCrescenteMoon()
        {
            return CountDrawnNumbers(QuartoCrescente);
        }

        public int[] GetQuarterWanningMoon()
        {
            return CountDrawnNumbers(QuartoMinguante);
        }

        public int[] GetWaningMoons()
        {
            return CountDrawnNumbers(Minguante);
        }
    }
}