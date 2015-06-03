using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSControlModule;
using GPSControlModule.Model;
using GPSService;


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
            IGPSService service = new GPSService.GPSService();
            IControlModule controlModule = new ControlModule(service);

            return controlModule;
        }

        private static void Finish(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
