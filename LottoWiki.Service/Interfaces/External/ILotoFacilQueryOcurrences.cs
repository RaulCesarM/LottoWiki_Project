using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryOcurrences
    {
        LotoFacilViewModelSmal GetLast();

        LotoFacilViewModelSmal GetById(int id);
    }
}