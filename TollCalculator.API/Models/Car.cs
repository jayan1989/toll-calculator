namespace TollCalculator.API.Models
{
    public class Car : IVehicle
    {
        public bool IsTollFreeVehicle() => false;        
    }
}
