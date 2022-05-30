namespace TollCalculator.API.Infrastructure.Dtos
{
    public class TollFeeRequestDto
    {
        public VehicleType VehicleType { get; set; }
        public IList<DateTime> Dates { get; set; }
    }
}
