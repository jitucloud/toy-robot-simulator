using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Model;
using ToyRobot.Commands;
using ToyRobot.Enumeration;

namespace ToyRobot.Tests
{
    [TestClass]
    public class MoveForwardCommandTest
    {
        [TestMethod]
        public void Move_TableTopFiveIntoFiveRobotNotPlacedBeforeMove()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            IMoveInterface moveCommand = new MoveForwardCommand(tr, tt);

            //act
            moveCommand.Execute();

            //assert
            Assert.IsFalse(tr.isRobotPlaced);
        }

        [TestMethod]
        public void Move_TableTopFiveIntoFiveRobotIsPlacedBeforeMove()
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
            placeCommand.Execute();

            IMoveInterface moveCommand = new MoveForwardCommand(tr, tt);

            //act
            moveCommand.Execute();

            //assert
            Assert.IsTrue(tr.isRobotPlaced);
        }

        [TestMethod]
        public void Move_TableTopFiveIntoFiveAlreadyPlacedMovedTwiceForward()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 3),
                Facing = Facing.NORTH
            };
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();

            IMoveInterface moveCommand = new MoveForwardCommand(tr, tt);

            //act
            moveCommand.Execute();
            moveCommand.Execute();


            //assert: actual/expected
            Assert.AreEqual(tr.GetCurrentRobotPosition(), new ToyRobot(new Coordinate(3, 5), Facing.NORTH).GetCurrentRobotPosition());
        }


        [TestMethod]
        public void Move_TableTop5Into5Placed3Into3RobotMovedFiveTimesForward()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 3),
                Facing = Facing.NORTH
            };
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();

            IMoveInterface moveCommand = new MoveForwardCommand(tr, tt);

            //act
            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();


            //assert: actual/expected
            Assert.IsTrue(tr.RobotStillOnTableTop(tt));
        }

        [TestMethod]
        public void Move_TableTop5Into5Placed2Into3RobotMovedOnceSameFacing()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(2, 3),
                Facing = Facing.NORTH
            };
            IMoveInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            placeCommand.Execute();

            IMoveInterface moveCommand = new MoveForwardCommand(tr, tt);

            //act
            moveCommand.Execute();

            //assert: actual/expected
            // Assert.AreEqual(tr.GetCurrentRobotPosition(), new ToyRobot(new Coordinate(3, 5), Facing.NORTH).GetCurrentRobotPosition());
            Assert.AreEqual(tr.robotDirection, Facing.NORTH);
        }
    }
}
