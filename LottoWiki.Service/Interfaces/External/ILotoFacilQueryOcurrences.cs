using LottoWiki.Service.ViewModels.Entities;

namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryOcurrences
    {
        LotoFacilViewModelSmal GetLast();

        LotoFacilViewModelSmal GetById(int id);

        LotoFacilViewModelSmal GetById(int id, int interval);

        int GetFrequency(int numero, int concurso, int range);

        int GetRequiredContest(int numero, int concurso, int range);
    }
}