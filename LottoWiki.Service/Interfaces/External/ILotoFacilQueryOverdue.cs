using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryOverdue
    {
        LotoFacilOverDueSmalViewModel GetLast();

        LotoFacilOverDueSmalViewModel GetById(int id);
    }
}