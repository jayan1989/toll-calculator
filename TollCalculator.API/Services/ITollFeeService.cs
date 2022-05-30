namespace TollCalculator.API.Services
{
    public interface ITollFeeService
    {
        public int GetTollFeeForDate(DateTime time);
    }
}
