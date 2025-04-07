namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryStatus
    {
        char[] GetLast();

        int GetLastId();

        char[] GetById(int id);

        char[] GetByLuckyBall(int id, int col, int qtd);
    }
}