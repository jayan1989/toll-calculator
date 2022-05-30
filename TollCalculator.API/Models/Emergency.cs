namespace TollCalculator.API.Models
{
    public class Emergency : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
