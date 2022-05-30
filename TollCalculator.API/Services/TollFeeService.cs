namespace TollCalculator.API.Services
{
    public class TollFeeService : ITollFeeService
    {
        private readonly List<TollFee> _tollFeeList;
        private readonly IDateService _dateService;

        public TollFeeService(IDateService dateService)
        {
            _tollFeeList = new List<TollFee>();
            _dateService = dateService;
            InitializeTollFeeList();
        }

        public int GetTollFeeForDate(DateTime date)
        {
            if (_dateService.IsTollFreeDate(date)) return 0;

            return _tollFeeList.SingleOrDefault(x => x.From.ToTimeSpan() <= date.TimeOfDay && x.To.ToTimeSpan() >= date.TimeOfDay)?.Fee ?? 0;
        }

        private void InitializeTollFeeList()
        {
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(6, 0, 0), to: TollTime.Create(6, 29, 59), fee: 8));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(6, 30, 0), to: TollTime.Create(6, 59, 59), fee: 13));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(7, 0, 0), to: TollTime.Create(7, 59, 59), fee: 18));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(8, 0, 0), to: TollTime.Create(8, 29, 59), fee: 13));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(8, 30, 0), to: TollTime.Create(14, 59, 59), fee: 8));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(15, 0, 0), to: TollTime.Create(15, 29, 59), fee: 13));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(15, 30, 0), to: TollTime.Create(16, 59, 59), fee: 18));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(17, 0, 0), to: TollTime.Create(17, 59, 59), fee: 13));
            _tollFeeList.Add(TollFee.Create(from: TollTime.Create(18, 0, 0), to: TollTime.Create(18, 59, 59), fee: 8));
        }
    }
}
