using MarsRoverProblem.Concrete;
using MarsRoverProblem.Constant.Enum;
using MarsRoverProblem.Service.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRoverProblem.UnitTest
{
    [TestClass]
    public class MarsRoverProblemTest
    {
        [TestMethod]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            Coordinates coordinates = new Coordinates(1, 2, Directions.N);
            Plateau plateau = new Plateau(5, 5);
            var roverManager = new MarsRoverManager(plateau, coordinates, coordinates.Direction);

            var moves = "LMLMLMLMM";

            var result = roverManager.StartMovingRover(moves);

            var actualOutput = $"{result.X} {result.Y} {result.Direction}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_33E_MMRMMRMRRM()
        {
            Coordinates coordinates = new Coordinates(3, 3, Directions.E);
            Plateau plateau = new Plateau(5, 5);
            var roverManager = new MarsRoverManager(plateau, coordinates, coordinates.Direction);

            var moves = "MMRMMRMRRM";

            var result = roverManager.StartMovingRover(moves);

            var actualOutput = $"{result.X} {result.Y} {result.Direction}";
            var expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
