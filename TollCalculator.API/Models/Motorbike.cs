namespace TollCalculator.API.Models
{
    public class Motorbike : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
