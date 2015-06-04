using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalileoService.Model;

namespace GalileoService
{
    public interface IGetPointer
    {
        PositionPointer GetPointer();
    }
}
