namespace TollCalculator.API.Services
{
    public interface IDateService
    {
        bool IsTollFreeDate(DateTime date);
    }
}
