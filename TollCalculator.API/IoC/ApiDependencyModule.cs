namespace TollCalculator.API.IoC
{
    public class ApiDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();

            builder.RegisterType<VehicleFactory>().AsSelf();

            builder.RegisterType<Car>().Keyed<IVehicle>(VehicleType.Car);
            builder.RegisterType<Motorbike>().Keyed<IVehicle>(VehicleType.Motorbike);
            builder.RegisterType<Tractor>().Keyed<IVehicle>(VehicleType.Tractor);
            builder.RegisterType<Emergency>().Keyed<IVehicle>(VehicleType.Emergency);
            builder.RegisterType<Military>().Keyed<IVehicle>(VehicleType.Military);
            builder.RegisterType<Diplomat>().Keyed<IVehicle>(VehicleType.Diplomat);
            builder.RegisterType<Foreign>().Keyed<IVehicle>(VehicleType.Foreign);

            builder.Register<VehicleDelegate>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return attr => c.ResolveKeyed<IVehicle>(attr);
            });
        }
    }
}
