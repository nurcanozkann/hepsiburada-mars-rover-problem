using MarsRoverProblem.Concrete;
using MarsRoverProblem.Constant.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Abstract
{
    public interface IRover
    {
        Plateau plateau { get; set; }

        Coordinates coordinates { get; set; }

        Directions heading { get; set; }
    }
}
