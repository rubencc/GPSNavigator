using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;
using GPSControlModule.Interceptores;
using GPSControlModule.Model;

namespace GPSControlModule
{
    //Asociamos el interceptor a la clase
    [Intercept(typeof(ServiceInterceptor))]
    public interface IControlModule
    {
        bool Start();
        bool Stop();
        Marker GetPosition();
        float GetSpeed();
    }
}
