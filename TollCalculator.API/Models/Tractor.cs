namespace TollCalculator.API.Models
{
    public class Tractor : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
