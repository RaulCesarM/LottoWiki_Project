using LottoWiki.Domain.Models.Base;
using LottoWiki.Service.Interfaces.Internal;
using LottoWiki.Service.Interfaces.Supply;
using LottoWiki.Service.Utils;
using LottoWiki.Service.ViewModels.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LottoWiki.Service.Services.LotoFacilSupply
{
    public class LotoFacilSupply : ILotoFacilSupply
    {
        private readonly HttpClient _client = new() { MaxResponseContentBufferSize = 1_000_000 };
        private readonly ILogger<LotoFacilSupply> _logger;
        private readonly ILotoFacilService _services;
        private readonly int _nextContest;
        private readonly string _url;

        public LotoFacilViewModel LotofacilViewModel { get; set; } = new();
        public LotoFacilJson Deserialized { get; set; } = new();

        public LotoFacilSupply(ILotoFacilService services, IConfiguration configuration, ILogger<LotoFacilSupply> logger)
        {
            _url = configuration.GetSection("LotofacilApi")["Url"];
            _services = services;
            _nextContest = _services.GetNextId();
            _logger = logger;
        }

        public bool HasNext()
        {
            string resultUrl = GetResultUrl().Result;
            if (resultUrl.IsNullOrEmpty())
            {
                return false;
            }

            Deserialized = JsonConvert.DeserializeObject<LotoFacilJson>(resultUrl);
            Populate();
            Save().Wait();
            return true;
        }

        private async Task<string> GetResultUrl()
        {
            try
            {
                string resultUrl = await _client.GetStringAsync($"{_url}/{_nextContest}");

                if (string.IsNullOrWhiteSpace(resultUrl))
                {
                    return null;
                }

                return resultUrl;
            }
            catch (HttpRequestException ex)
            {
                var msg = $"Concurso ainda não foi lançado {_nextContest} / causa {ex.Source}";
                _logger.LogMethodInfo(msg);
                return null;
            }
        }

        private void Populate()
        {
            try
            {
                LotofacilViewModel.LuaDoSorteio = CalculateMoonPhase.CalcularPhase(Deserialized.DataApuracao);
                LotofacilViewModel.NomeMunicipioUFSorteio = Deserialized.NomeMunicipioUFSorteio;
                LotofacilViewModel.ConcursoAnterior = Deserialized.NumeroConcursoAnterior;
                LotofacilViewModel.ProximoConcurso = Deserialized.NumeroConcursoProximo;
                LotofacilViewModel.DataApuracao = Deserialized.DataApuracao;
                LotofacilViewModel.Concurso = Deserialized.Numero;
                LotofacilViewModel.Macro_Estado = 0;
                for (int i = 0; i < 15; i++)
                {
                    int ballNumber = i + 1;
                    int luckyBall = Deserialized.DezenasSorteadasOrdemSorteio[i];
                    LotofacilViewModel.Macro_Estado += luckyBall;
                    string propertyName = $"Casa_{(ballNumber < 10 ? "0" : "")}{ballNumber}";
                    var property = LotofacilViewModel.GetType().GetProperty(propertyName);
                    property.SetValue(LotofacilViewModel, luckyBall);
                }
            }
            catch (Exception ex)
            {
                var msg = $"LotoFacil não foi populada / causa {ex.Message}";
                _logger.LogMethodInfo(msg);
            }
        }

        private async Task Save()
        {
            try
            {
                await _services.Insert(LotofacilViewModel);
            }
            catch (Exception ex)
            {
                var msg = $"LotoFacil não foi persistida / causa {ex.Message}";
                _logger.LogMethodInfo(msg);
            }
        }
    }
}