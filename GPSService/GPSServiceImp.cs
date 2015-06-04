using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSService
{
    public class GPSServiceImp : IGPSService
    {
        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public double GetLatitude()
        {
            Random rd = new Random(DateTime.Now.Millisecond);

            return rd.Next(-90, 90) + rd.NextDouble();
        }

        public double GetLongitude()
        {
            Random rd = new Random();

            return rd.Next(-180, 180) + rd.NextDouble();
        }

        public double GetAltitude()
        {
            Random rd = new Random();

            return rd.Next(0, 3000);
        }

        public double GetSpeed()
        {
            Random rd = new Random();

            return rd.Next(0, 150);
        }
    }
}
