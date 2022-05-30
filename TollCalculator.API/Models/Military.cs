namespace TollCalculator.API.Models
{
    public class Military : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
