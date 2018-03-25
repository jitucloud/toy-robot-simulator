using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;
using ToyRobot.Model;
using ToyRobot.Enumeration;

namespace ToyRobot.Tests
{
    [TestClass]
    public class TurnRightCommandTest
    {
        [TestMethod]
        public void Turnright_TableTopFiveIntoFiveRobotNotPlacedBeforeTurnLeft()
        {
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            IMoveInterface turnRight = new TurnRightCommand(tr);
            //act
            turnRight.Execute();
            //assert
            Assert.IsFalse(tr.isRobotPlaced);
        }

        [TestMethod]
        public void Turnright_TableTopFiveIntoFiveRobotIsPlacedBeforeMove()
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

            IMoveInterface rightCommand = new TurnRightCommand(tr);

            //act
            rightCommand.Execute();

            //assert
            Assert.IsTrue(tr.isRobotPlaced);
        }


        [TestMethod]
        public void Turnright_TableTop5Into5RobotTurnedRightTwice()
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
            IMoveInterface rightCommand = new TurnRightCommand(tr);

            //act
            rightCommand.Execute();
            rightCommand.Execute();


            //assert
            Assert.AreEqual(tr.robotDirection, Facing.SOUTH);
        }

        [TestMethod]
        public void Turnright_TableTop5Into5RobotTurnedRightFourTimesSameFacing_IsTrue()
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
            IMoveInterface rightCommand = new TurnRightCommand(tr);

            //act
            rightCommand.Execute();
            rightCommand.Execute();
            rightCommand.Execute();
            rightCommand.Execute();

            //assert
            Assert.AreEqual(tr.robotDirection, Facing.NORTH);
        }
    }
}
