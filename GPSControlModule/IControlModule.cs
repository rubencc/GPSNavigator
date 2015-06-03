using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSControlModule.Model;

namespace GPSControlModule
{
    public interface IControlModule
    {
        bool Start();
        bool Stop();
        Marker GetPosition();
        float GetSpeed();
    }
}
