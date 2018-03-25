using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;
using ToyRobot.Model;
using ToyRobot.Enumeration;

namespace ToyRobot.Tests
{
    /// <summary>
    /// Turn left Command Test class
    /// </summary>
    [TestClass]
    public class TurnLeftCommandTest
    {
        [TestMethod]
        public void Turnleft_TableTopFiveIntoFiveRobotNotPlacedBeforeTurnLeft()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            ICommandInterface leftCommand = new TurnLeftCommand(tr);
            //act
            leftCommand.Execute();
            //assert
            Assert.IsFalse(tr.isRobotPlaced);
        }

        [TestMethod]
        public void Turnleft_TableTopFiveIntoFiveRobotIsPlacedBeforeMove()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 4),
                Facing = Facing.NORTH
            };
            ICommandInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();

            ICommandInterface leftCommand = new TurnLeftCommand(tr);

            //act
            leftCommand.Execute();

            //assert
            Assert.IsTrue(tr.isRobotPlaced);
        }


        [TestMethod]
        public void Turnleft_TableTop5Into5RobotTurnedLeftTwice()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 4),
                Facing = Facing.NORTH
            };
            ICommandInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();
            ICommandInterface leftCommand = new TurnLeftCommand(tr);

            //act
            leftCommand.Execute();
            leftCommand.Execute();


            //assert
            Assert.AreEqual(tr.robotDirection, Facing.SOUTH);
        }

        [TestMethod]
        public void Turnleft_TableTop5Into5RobotTurnedLeftFourTimesSameFaing_IsTrue()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 4),
                Facing = Facing.NORTH
            };
            ICommandInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();
            ICommandInterface leftCommand = new TurnLeftCommand(tr);

            //act
            leftCommand.Execute();
            leftCommand.Execute();
            leftCommand.Execute();
            leftCommand.Execute();

            //assert
            Assert.AreEqual(tr.robotDirection, Facing.NORTH);
        }
    }
}
