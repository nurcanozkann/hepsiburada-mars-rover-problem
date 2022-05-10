using MarsRoverProblem.Service.Abstract;
using MarsRoverProblem.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using MarsRoverProblem.Concrete;
using MarsRoverProblem.Constant.Enum;
using MarsRoverProblem.Core.Constant.EnumExtensions;
using System.Collections.Generic;

namespace MarsRoverProblem.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //second solution method
            //var roverList = new List<Rover>();
            //var coordinatesList = new List<Coordinates>();
            ////Get values plateau
            //Console.WriteLine("Plateau Values");
            //var plateauFieldValues = Console.ReadLine().Trim().Split(' ');
            //// Create plateau data
            //var plateauResult = new Plateau(Convert.ToInt32(plateauFieldValues[0]), Convert.ToInt32(plateauFieldValues[1]));

            //while (true)
            //{
            //    //Get current coordinates value
            //    Console.WriteLine("Rover Current position :");
            //    var roverPositionInput = Console.ReadLine().Trim().Split(' ');

            //    //Create coorinates data
            //    var coordinatesResult = new Coordinates(Convert.ToInt32(roverPositionInput[0]), Convert.ToInt32(roverPositionInput[1]), roverPositionInput[2].ToEnumValue<Directions>());

            //    //Get nasa code
            //    Console.WriteLine("Nasa Code :");
            //    var roverCommandInput = Console.ReadLine().Trim().Split(' ');

            //    //Create rover data
            //    var roverResult = new Rover(plateauResult, coordinatesResult, roverCommandInput);
            //    //add another rover
            //    roverList.Add(roverResult);
            //    Console.WriteLine("Do you want to add another rover ? (Y/N)");
            //    var addRoverInput = Console.ReadLine();

            //    if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            //        break;
            //}

            //foreach (var item in roverList)
            //{
            //    // Send data to rover manager
            //    var marsRoverManagerResult = new MarsRoverManager(item.Plateau, item.Coordinates, item.Coordinates.Direction);
            //    var coordinatesResult = marsRoverManagerResult.StartMovingRover(item.NasaCode[0].ToString());
            //    coordinatesList.Add(coordinatesResult);
            //}

            //// Final rover location
            //if (coordinatesList.Count != 0 && coordinatesList != null)
            //    Console.WriteLine(string.Format("Final rover location1- X: {0} Y: {1} Direction: {2} // Final rover location2- X: {3} Y: {4} Direction: {5}", coordinatesList[0].X, coordinatesList[0].Y, coordinatesList[0].Direction, coordinatesList[1].X, coordinatesList[1].Y, coordinatesList[1].Direction));
            //else
            //    Console.WriteLine("Invalid Command");


            //Get values plateau
            Console.WriteLine("Plateau Values");
            var plateauValues = Console.ReadLine().Trim().Split(' ');

            //Get current coordinates value
            Console.WriteLine("Rover Current Position");
            var currentPosition = Console.ReadLine().Trim().Split(' ');

            //Get nasa code
            Console.WriteLine("Nasa Code");
            var nasaCode = Console.ReadLine();

            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);
            // create service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            // entry to logging app
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
            // add services, add logging
            services.AddLogging(configure => configure.AddConsole()).AddTransient<Logging.Logging>();
            services.AddSingleton<IMarsRoverService, MarsRoverManager>();

            //Now that we have our Dependency Injection wired up, we need to setup logging.
        }
    }
}
