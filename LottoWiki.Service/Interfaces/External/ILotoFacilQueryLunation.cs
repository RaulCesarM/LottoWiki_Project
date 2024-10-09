namespace LottoWiki.Service.Interfaces.External
{
    public interface ILotoFacilQueryLunation
    {
        int[] GetFullMoon();

        int[] GetNewMoon();

        int[] GetWaningMoons();

        int[] GetCrescentMoon();

        int[] GetQuarterCrescenteMoon();

        int[] GetGibbousCrescentMoon();

        int[] GetGibbousWaningMoon();

        int[] GetQuarterWanningMoon();
    }
}