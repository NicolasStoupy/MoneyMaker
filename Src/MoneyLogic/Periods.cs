using static System.Net.Mime.MediaTypeNames;

namespace MoneyLogic
{
    public class Periods
    {
        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public PeriodType PeriodType { get; private set; } = PeriodType.notDefined;

        private Periods(DateOnly start, DateOnly end, PeriodType periodType)
        {
            StartDate = start; EndDate = end; PeriodType = periodType;
        }
        public DateOnly NextOperationTime(DateOnly? fromDate = null)
        {
            if (PeriodType == PeriodType.notDefined)
                throw new InvalidOperationException("La période n'est pas définie.");

            var referenceDate = fromDate ?? DateOnly.FromDateTime(DateTime.Today);
            var next = StartDate;

            while (next < referenceDate)
            {
                next = PeriodType switch
                {
                    PeriodType.daily => next.AddDays(1),
                    PeriodType.weekly => next.AddDays(7),
                    PeriodType.monthly => next.AddMonths(1),
                    PeriodType.yearly => next.AddYears(1),
                    _ => throw new InvalidOperationException("Période inconnue.")
                };
            }

            if (next > EndDate)
                throw new InvalidOperationException("La prochaine opération serait après la date de fin.");

            return next;
        }

        public static Periods NewPeriods(DateOnly startDate, DateOnly endDate, PeriodType periodType)
        {
            return new Periods(startDate, endDate, periodType);
        }

        public int CountExecutionsUntil(DateOnly date)
        {
            var referenceDate = date;
            var next = StartDate;
            int counter = 1;
            while (next < referenceDate)
            {
                counter++;
                next = PeriodType switch
                {
                    PeriodType.daily => next.AddDays(1),
                    PeriodType.weekly => next.AddDays(7),
                    PeriodType.monthly => next.AddMonths(1),
                    PeriodType.yearly => next.AddYears(1),
                    _ => throw new InvalidOperationException("Période inconnue.")
                };
            }

            return counter;
        }
    }

}
public enum PeriodType
{
    notDefined, daily, monthly, weekly, yearly
}

