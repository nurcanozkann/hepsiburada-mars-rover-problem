using MarsRoverProblem.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem.Concrete
{
    /// <summary>
    /// Create Plateau class
    /// </summary>
    public class Plateau : IPlateau
    {
        private int width;
        private int height;

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return this.width; }

            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }

            set { this.height = value; }
        }

    }
}
