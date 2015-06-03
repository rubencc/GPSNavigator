using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSService
{
    public interface IGPSService
    {
        void Start();
        void Stop();
        double GetLatitude();
        double GetLongitude();
        double GetAltitude();
        double GetSpeed();
    }
}
