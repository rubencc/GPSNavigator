using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalileoService
{
    public interface IManageGalileoService
    {
        void Sync();
        void Dispose();
    }
}
