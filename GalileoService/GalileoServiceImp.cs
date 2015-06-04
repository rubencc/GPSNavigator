using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalileoService.Model;

namespace GalileoService
{
    public class GalileoServiceImp : IGalileoService
    {
        public Model.PositionPointer GetPointer()
        {
            Random rd = new Random();

            PositionPointer pointer = new PositionPointer()
            {
                Altitude = rd.Next(0,4000),
                Longitude = rd.Next(-180, 180) + rd.NextDouble(),
                Latitude = rd.Next(-90, 90) + rd.NextDouble(),
                Speed = rd.Next(0, 150)
            };

            return pointer;
        }

        public void Sync()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
