namespace TollCalculator.API.Models
{
    public class Diplomat : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
