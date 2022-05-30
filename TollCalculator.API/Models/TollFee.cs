namespace TollCalculator.API.Models
{
    public class TollFee
    {
        public TollTime From { get; private set; }
        public TollTime To { get; private set; }
        public int Fee { get; private set; }

        public static TollFee Create(TollTime from, TollTime to, int fee)
        {
            if (from.Hour < to.Hour || (from.Hour == to.Hour && from.Minute <= to.Minute))
            {
                return new TollFee
                {
                    From = from,
                    To = to,
                    Fee = fee
                };
            }

            throw new ArgumentException("To time cannot be less than From time");
        }
    }
}
