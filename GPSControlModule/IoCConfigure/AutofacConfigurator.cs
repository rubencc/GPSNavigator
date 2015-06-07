using Autofac;
using GalileoService;
using GPSControlModule.Adapter;
using GPSService;
using IoCConfiguration;

namespace GPSControlModule.IoCConfigure
{
    public class AutofacConfigurator : IConfigIoC
    {
        private readonly ContainerBuilder containerBuilder;

        public AutofacConfigurator(ContainerBuilder containerBuilder)
        {
            this.containerBuilder = containerBuilder;
        }

        public void Configure()
        {
            //Servicio por defecto
            //this.containerBuilder.RegisterType<GPSServiceImp>().As<IGPSService>();

            //O bien podemos usar el adaptador
            this.containerBuilder.RegisterType<GalileoServiceImp>().As<IGalileoService>();
            this.containerBuilder.RegisterType<GalileoServiceAdapter>().As<IGPSService>();

            //Registro del modulo de control
            this.containerBuilder.RegisterType<ControlModule>().As<IControlModule>();
        }
    }
}
