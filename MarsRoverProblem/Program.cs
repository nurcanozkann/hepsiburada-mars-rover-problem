using MarsRoverProblem.Service.Abstract;
using MarsRoverProblem.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using MarsRoverProblem.Concrete;
using MarsRoverProblem.Constant.Enum;
using MarsRoverProblem.Core.Constant.EnumExtensions;

namespace MarsRoverProblem.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Get values plateau
            Console.WriteLine("Plateau Values");
            var plateauValues = Console.ReadLine().Trim().Split(' ');
            //Get current coordinates value
            Console.WriteLine("Rover Current Position");
            var currentPosition = Console.ReadLine().Trim().Split(' ');
            //Get nasa code
            Console.WriteLine("Nasa Code");
            var nasaCode = Console.ReadLine();

            var services = new ServiceCollection();          
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Logging.Logging app = serviceProvider.GetService<Logging.Logging>();

            // Create plateau data
            var plateau = new Plateau(Convert.ToInt32(plateauValues[0]), Convert.ToInt32(plateauValues[1]));
            //Create coorinates data
            var coordinates = new Coordinates(Convert.ToInt32(currentPosition[0]), Convert.ToInt32(currentPosition[1]), currentPosition[2].ToEnumValue<Directions>());
            // Send data to rover manager
            var marsRoverManager = new MarsRoverManager(plateau, coordinates, coordinates.Direction);
          
            try
            {
                // Start moving the rover on incoming values.
                coordinates = marsRoverManager.StartMovingRover(nasaCode);
                // Final rover location
                if (coordinates != null)
                    Console.WriteLine(string.Format("Final rover location- X: {0} Y: {1} Direction: {2}", coordinates.X, coordinates.Y, coordinates.Direction));
                else
                    Console.WriteLine("Invalid Command");

                app.Start();
            }
            catch (Exception ex)
            {
                app.HandleError(ex);
            }
            finally
            {
                app.Stop();
            }

            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole()).AddTransient<Logging.Logging>();
            services.AddSingleton<IMarsRoverService, MarsRoverManager>();
        }
    }
}
