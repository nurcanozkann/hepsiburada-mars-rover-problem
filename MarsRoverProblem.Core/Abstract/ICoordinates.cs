using MarsRoverProblem.Constant.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Abstract
{
    public interface ICoordinates
    {
        int X { get; set; }

        int Y { get; set; }

        Directions Direction { get; set; }
    }
}
