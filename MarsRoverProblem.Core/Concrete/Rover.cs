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
        private string[] nasaCode;

        public Rover(Plateau plateau, Coordinates coordinates, string[] nasaCode)
        {
            this.plateau = plateau;
            this.coordinates = coordinates;
            this.nasaCode = nasaCode;
        }

        public Plateau Plateau
        {
            get { return this.plateau; }

            set { this.plateau = value; }
        }

        public Coordinates Coordinates
        {
            get { return this.coordinates; }

            set { this.coordinates = value; }
        }

        public string[] NasaCode
        {
            get { return this.nasaCode; }

            set { this.nasaCode = value; }
        }

    }
}
