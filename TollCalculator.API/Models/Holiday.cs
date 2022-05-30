namespace TollCalculator.API.Models
{
    public class Holiday
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public bool AllDays { get; set; }
        public IEnumerable<int> Days { get; set; }
    }
}
