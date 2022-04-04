using MarsRoverProblem.Concrete;

namespace MarsRoverProblem.Service.Abstract
{
    public interface IMarsRoverService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="nasaCode"></param>
        /// <returns></returns>
        Coordinates StartMovingRover(string nasaCode);
        //Coordinates StartMovingRover(string[] plateauValues, string[] currentPosition, string nasaCode);
    }
}
