using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Model;
using ToyRobot.Commands;
using ToyRobot.Enumeration;

namespace ToyRobot.Tests
{
    [TestClass]
    public class PlaceRobotPositionCommandTest
    {
        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceZeroIntoZeroIsTrue()
        {
            TableTop tt = new TableTop(5, 5);
            Assert.IsTrue(tt.IsRobotInTableTopRange(new Coordinate(0, 0)), "True");
        }

        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceFourIntoFourIsTrue()
        {
            TableTop tt = new TableTop(5, 5);
            Assert.IsTrue(tt.IsRobotInTableTopRange(new Coordinate(4, 4)), "True");
        }

        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceFiveIntoSixIsFalse()
        {
            TableTop tt = new TableTop(5, 5);
            Assert.IsFalse(tt.IsRobotInTableTopRange(new Coordinate(5, 6)), "False");
        }

        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceMinusOneIntoMinusTwoIsFalse()
        {
            TableTop tt = new TableTop(5, 5);
            Assert.IsFalse(tt.IsRobotInTableTopRange(new Coordinate(-1, -2)), "False");
        }

        [TestMethod]
        public void Place_TableTop5Into5PlaceCommandIsRobotPlaced()
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
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);

            //act
            placeCommand.Execute();

            //assert
            Assert.IsTrue(tr.isRobotPlaced);
        }

        [TestMethod]
        public void Place_TableTop5Into5PlaceCommandRobotNotPlaced()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 6),
                Facing = Facing.NORTH
            };
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);

            //act
            placeCommand.Execute();

            //assert
            Assert.IsFalse(tr.isRobotPlaced);
        }


        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceCoordinatesToThreeIntoFourAreEqual()
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
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);

            //act
            placeCommand.Execute();

            //assert
            Assert.AreEqual(tr.GetCurrentRobotPosition(), new ToyRobot(new Coordinate(3, 4), Facing.NORTH).GetCurrentRobotPosition());
        }

        [TestMethod]
        public void Place_TableTopFiveIntoFivePlaceCoordinatesToThreeIntoSevenIsNull()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 7),
                Facing = Facing.NORTH
            };
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);

            //act
            placeCommand.Execute();

            //assert
            Assert.IsNull(tr.GetCurrentRobotPosition());
        }
    }
}
