namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryStatus
    {
        char[] GetLast();

        int GetLastId();

        char[] GetById(int id);
    }
}