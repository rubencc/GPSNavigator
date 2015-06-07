using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalileoService;
using GalileoService.Model;
using GPSService;

namespace GPSControlModule.Adapter
{
    public class GalileoServiceAdapter : IGPSService
    {
        private readonly IGalileoService galileoService;

        public GalileoServiceAdapter(IGalileoService galileoService)
        {
            this.galileoService = galileoService;
        }

        public void Start()
        {
            this.galileoService.Sync();
        }

        public void Stop()
        {
            this.galileoService.Dispose();
        }

        public double GetLatitude()
        {
            PositionPointer pointer = this.galileoService.GetPointer();
            return pointer.Latitude;
        }

        public double GetLongitude()
        {
            PositionPointer pointer = this.galileoService.GetPointer();
            return pointer.Longitude;
        }

        public double GetAltitude()
        {
            PositionPointer pointer = this.galileoService.GetPointer();
            return pointer.Altitude <= 3000 ? pointer.Altitude : 3000;
        }

        public double GetSpeed()
        {
            PositionPointer pointer = this.galileoService.GetPointer();
            return (double)pointer.Speed;
        }
    }
}
