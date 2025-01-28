using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryDoOver
    {
        LotoFacilViewModelSmal GetLast();

        LotoFacilViewModelSmal GetById(int id);
    }
}