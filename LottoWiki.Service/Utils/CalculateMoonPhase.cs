using System.Globalization;

namespace LottoWiki.Service.Utils
{
    public static class CalculateMoonPhase
    {
        public static string CalcularPhase(DateTime data)
        {
            string[] phases = { "Nova", "Crescente", "Quarto Crescente", "Gibosa Crescente", "Cheia", "Gibosa Minguante", "Quarto Minguante", "Minguante" };

            int year = data.Year;
            int month = data.Month;
            int day = data.Day;

            if (month < 3)
            {
                year--;
                month += 12;
            }

            month++;

            int hundredthYear = year / 100;
            int centuryLeapYears = hundredthYear / 4;
            int julianDateCorrection = 2 - hundredthYear + centuryLeapYears;
            int daysSinceEpoch = (int)(365.25 * (year + 4716));
            int daysInMonth = (int)(30.6001 * month);

            double julianDay = julianDateCorrection + day + daysSinceEpoch + daysInMonth - 1524.5;
            double dayLastNewMoon = julianDay - 2451550.1;
            double newsMoons = dayLastNewMoon / 29.53058867;
            double ageMoon = newsMoons - Math.Floor(newsMoons);

            int phase = (int)(ageMoon * 8 + 0.5) % 8;

            return phases[phase];
        }

        public static string CalcularPhase(String data)
        {
            string dateFormat = "dd/MM/yyyy";
            DateTime date = DateTime.ParseExact(data, dateFormat, CultureInfo.InvariantCulture);

            return CalcularPhase(date);
        }
    }
}