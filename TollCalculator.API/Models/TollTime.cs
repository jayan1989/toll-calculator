namespace TollCalculator.API.Models
{
    public class TollTime
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Seconds { get; private set; }

        public static TollTime Create(int hour, int minute, int seconds)
        {
            return new TollTime
            {
                Hour = hour,
                Minute = minute,
                Seconds = seconds
            };
        }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(Hour, Minute, Seconds);
        }
    }
}
