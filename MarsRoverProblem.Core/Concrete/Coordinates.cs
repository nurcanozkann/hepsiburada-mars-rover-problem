using MarsRoverProblem.Abstract;
using MarsRoverProblem.Constant.Enum;

namespace MarsRoverProblem.Concrete
{
    /// <summary>
    /// Create coordinates class
    /// </summary>
    public class Coordinates : ICoordinates
    {
        private int x;
        private int y;
        private Directions directions = Directions.N;

        public Coordinates(int x, int y, Directions directions)
        {
            this.x = x;
            this.y = y;
            this.directions = directions;
        }

        public int X
        {
            get { return this.x; }

            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }

            set { this.y = value; }
        }

        public Directions Direction
        {
            get { return this.directions; }

            set { this.directions = value; }
        }
    }
}
