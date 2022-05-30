namespace TollCalculator.API.Services
{
    public class DateService : IDateService
    {
        private readonly IHolidaysDataStore _holidaysDataStore;

        public DateService(IHolidaysDataStore holidaysDataStore)
        {
            _holidaysDataStore = holidaysDataStore;
        }

        public bool IsTollFreeDate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                _holidaysDataStore.Collection<Holiday>("Holidays")
                .Any(x => x.Year == date.Year && x.Month == date.Month && (x.Days.Contains(date.Day) || x.AllDays));
        }
    }
}
