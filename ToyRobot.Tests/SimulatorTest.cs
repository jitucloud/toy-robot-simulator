using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Enumeration;
using ToyRobot.Model;
using ToyRobot.Commands;

namespace ToyRobot.Tests
{
    [TestClass]
    public class SimulatorTest
    {
        [TestMethod]
        public void Simulator_ReturnPlaceRobotCommandObject()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            Simulator simulator = new Simulator(tr, tt);
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 4),
                Facing = Facing.NORTH
            };

            //act
            ICommandInterface placeRobotObject = simulator.Action(cm);

            //assert
            Assert.AreEqual(typeof(PlaceRobotCommand), placeRobotObject.GetType());
        }

        [TestMethod]
        public void Simulator_ReturnMoveRobotCommandObject()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot()
            {
                isRobotPlaced = true
            };
            Simulator simulator = new Simulator(tr, tt);
            CommandModel cm = new CommandModel()
            {
                Command = Command.MOVE
            };

            //act
            ICommandInterface MoveForwardCommandObject = simulator.Action(cm);

            //assert
            Assert.AreEqual(typeof(MoveForwardCommand), MoveForwardCommandObject.GetType());
        }



    }
}
