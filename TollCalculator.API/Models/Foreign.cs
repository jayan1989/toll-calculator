namespace TollCalculator.API.Models
{
    public class Foreign : IVehicle
    {
        public bool IsTollFreeVehicle() => true;
    }
}
