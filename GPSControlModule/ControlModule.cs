using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSControlModule.Model;
using GPSService;

namespace GPSControlModule
{
    public class ControlModule : IControlModule
    {
        private readonly IGPSService service;
        private bool running;

        public ControlModule(IGPSService service)
        {
            this.service = service;
        }

        public bool Start()
        {
            try
            {
                this.service.Start();
                this.running = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                this.service.Stop();
                this.running = false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Model.Marker GetPosition()
        {
            if (this.running)
            {
                Marker marker = new Marker()
                {
                    Altitude = this.service.GetAltitude(),
                    Latitude = this.service.GetLatitude(),
                    Longitude = this.service.GetLongitude()
                };

                return marker;
            }

            return new Marker();

        }


        public float GetSpeed()
        {
            if (this.running)
            {
                return (float)this.service.GetSpeed();
            }

            return 0;
        }
    }
}
