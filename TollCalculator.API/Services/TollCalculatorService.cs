namespace TollCalculator.API.Services
{
    public class TollCalculatorService : ITollCalculatorService
    {
        private readonly VehicleFactory _vehicleFactory;
        private readonly ITollFeeService _tollFeeService;

        public TollCalculatorService(VehicleFactory vehicleFactory,
            ITollFeeService tollFeeService)
        {
            _vehicleFactory = vehicleFactory;
            _tollFeeService = tollFeeService;
        }
        
        public int GetTollFee(TollFeeRequestDto tollFeeRequest)
        {
            ValidateDates(tollFeeRequest.Dates);

            IVehicle vehicle = _vehicleFactory.Create(tollFeeRequest.VehicleType);

            if (tollFeeRequest.Dates.Count == 0 || vehicle.IsTollFreeVehicle()) return 0;

            List<int> feesWithinSameHour = new();
            int totalFeeForDay = 0;

            foreach (var datesGroupedByHour in tollFeeRequest.Dates.OrderBy(x => x).GroupBy(x => x.Hour))
            {
                foreach (var date in datesGroupedByHour)
                {
                    int feeForDate = _tollFeeService.GetTollFeeForDate(date);
                    feesWithinSameHour.Add(feeForDate);
                }

                if (feesWithinSameHour.Count > 0)
                {
                    totalFeeForDay += feesWithinSameHour.Max();
                }

                feesWithinSameHour.Clear();
            }

            if (totalFeeForDay > 60) totalFeeForDay = 60;

            return totalFeeForDay;
        }

        private void ValidateDates(IEnumerable<DateTime> dates)
        {
            if (dates.GroupBy(d => new { d.Year, d.Month, d.Day }).Count() > 1)
            {
                throw new ArgumentException("All the dates should be in same day");
            }

            if (dates.Any(d => d > DateTime.Now))
            {
                throw new ArgumentException("Dates cannot be future dates");
            }
        }
    }
}
