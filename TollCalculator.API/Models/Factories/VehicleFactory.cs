namespace TollCalculator.API.Models.Factories
{
    public delegate IVehicle VehicleDelegate(VehicleType vehicleType);
    public class VehicleFactory
    {
        private VehicleDelegate _factory;

        public VehicleFactory(VehicleDelegate factory)
        {
            _factory = factory;
        }

        public IVehicle Create(VehicleType vehicleType)
        {
            return _factory(vehicleType);
        }
    }
}
