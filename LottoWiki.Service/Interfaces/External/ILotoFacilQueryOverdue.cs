using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryOverdue
    {
        LotoFacilViewModelSmal GetLast();

        LotoFacilViewModelSmal GetById(int id);
    }
}