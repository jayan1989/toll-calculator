namespace TollCalculator.API.Services
{
    public interface ITollCalculatorService
    {
        int GetTollFee(TollFeeRequestDto tollFeeRequest);
    }
}
