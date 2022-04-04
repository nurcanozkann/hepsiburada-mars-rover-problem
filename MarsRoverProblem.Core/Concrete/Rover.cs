using MarsRoverProblem.Abstract;
using MarsRoverProblem.Constant.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Concrete
{
    /// <summary>
    /// Create rover class
    /// </summary>
    public class Rover : IRover
    {
        private Plateau plateau;
        private Coordinates coordinates;
        private Directions direction = Directions.N;

        public Rover(Plateau plateau, Coordinates coordinates, Directions direction)
        {
            this.plateau = plateau;
            this.coordinates = coordinates;
            this.direction = direction;
        }

        public Directions heading { get; set; }
        Plateau IRover.plateau { get; set; }
        Coordinates IRover.coordinates { get; set; }
    }
}
