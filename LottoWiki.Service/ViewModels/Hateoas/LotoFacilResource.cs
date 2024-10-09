using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.ViewModels.Hateoas
{
    public class LotoFacilResource
    {
        public LotoFacilViewModel Data { get; set; }
        public IDictionary<string, string> Links { get; set; } = new Dictionary<string, string>();
    }
}