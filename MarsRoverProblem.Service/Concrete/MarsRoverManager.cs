using MarsRoverProblem.Concrete;
using MarsRoverProblem.Constant.Enum;
using MarsRoverProblem.Service.Abstract;
using System;

namespace MarsRoverProblem.Service.Concrete
{
    public class MarsRoverManager : IMarsRoverService
    {
        public static Directions HeadDirection = Directions.N;

        private readonly Plateau plateau;
        private readonly Coordinates coordinates;
        public MarsRoverManager(Plateau plateau, Coordinates coordinates, Directions headDirection)
        {
            this.plateau = plateau;
            this.coordinates = coordinates;
            HeadDirection = headDirection;
        }

        public Coordinates StartMovingRover(string nasaCode)
        {
            foreach (char code in nasaCode)
            {
                switch (code)
                {
                    case 'L':
                        this.MoveLeft();
                        break;

                    case 'R':
                        this.MoveRight();
                        break;

                    case 'M':
                        this.MoveForward();
                        break;

                    default:
                        Console.WriteLine($"Invalid Character {this.coordinates.Direction}");
                        break;
                }
            }

            return this.coordinates;
        }

        private void MoveLeft()
        {
            switch (HeadDirection)
            {
                case Directions.N:
                    HeadDirection = Directions.W;
                    break;
                case Directions.S:
                    HeadDirection = Directions.E;
                    break;
                case Directions.E:
                    HeadDirection = Directions.N;
                    break;
                case Directions.W:
                    HeadDirection = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void MoveRight()
        {
            switch (HeadDirection)
            {
                case Directions.N:
                    HeadDirection = Directions.E;
                    break;
                case Directions.S:
                    HeadDirection = Directions.W;
                    break;
                case Directions.E:
                    HeadDirection = Directions.S;
                    break;
                case Directions.W:
                    HeadDirection = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private bool MoveForward()
        {
            // Check if the coordinators match
            if (AreCoordinatesValid())
                return false;

            switch (HeadDirection)
            {
                // forward to the North
                case Directions.N:
                    this.coordinates.Y += 1;
                    break;

                // back to the South
                case Directions.S:
                    this.coordinates.Y -= 1;
                    break;

                // formard to the East
                case Directions.E:
                    this.coordinates.X += 1;
                    break;

                // back to the west
                case Directions.W:
                    this.coordinates.X -= 1;
                    break;
                default:
                    break;
            }

            return true;
        }

        private bool AreCoordinatesValid()
        {
            return this.coordinates.X < 0 || this.coordinates.X > this.plateau.Width || this.coordinates.Y < 0 || this.coordinates.Y > this.plateau.Height;
        }
    }
}

