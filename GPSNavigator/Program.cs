using System;
using System.Security.Permissions;
using System.Text;
using Autofac;
using GPSControlModule;
using GPSControlModule.IoCConfigure;
using GPSControlModule.Model;
using IoCConfiguration;


namespace GPSNavigator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IControlModule controlModule = GetControlModule();
            try
            {
                if (controlModule.Start())
                {
                    ShowInfo(controlModule);              

                    controlModule.Stop();
                    Finish(String.Empty);
                }
                else
                {
                    Finish("El navegador no esta disponible");
                }
            }
            catch (Exception ex)
            {
                Finish(ex.Message);
            }

        }

        private static void ShowInfo(IControlModule controlModule)
        {
            StringBuilder sb = new StringBuilder();
            Marker marker = controlModule.GetPosition();

            sb.AppendFormat("Velocidad: {0} {1}", controlModule.GetSpeed(), Environment.NewLine);
            sb.AppendFormat("Longitud: {0} {1}", marker.Longitude, Environment.NewLine);
            sb.AppendFormat("Latitud: {0} {1}", marker.Latitude, Environment.NewLine);
            sb.AppendFormat("Altitud: {0} {1}", marker.Altitude, Environment.NewLine);

            Console.WriteLine(sb.ToString());
        }

        private static IControlModule GetControlModule()
        {
            IContainer builder = ConfigureIoC();

            IControlModule controlModule = builder.Resolve<IControlModule>();

            return controlModule;
        }

        //Configura en el IoC tanto los registros de este proyecto como los de 
        //los proyectos de los que depende. Excepto los de los servicios
        //que son tratados como Dll de terceros y por tanto no podemos
        //como si fueran codigo propio 
        private static IContainer ConfigureIoC()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            IConfigIoC autofacManager = new AutofacConfigurator(containerBuilder);
            autofacManager.Configure();
            IContainer builder = containerBuilder.Build();

            return builder;
        }

        private static void Finish(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
