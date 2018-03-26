using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Model;
using ToyRobot.Enumeration;
using ToyRobot.Commands;

namespace ToyRobot.Tests
{
    [TestClass]
    public class ToyRobotTest
    {
        [TestMethod]
        public void ToyRobot_TableTop5Into5PlaceRobot3Into3AndRobotOnTableTopIsTrue()
        {
            //arrange
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 3),
                Facing = Facing.NORTH
            };
            ICommandInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            //act
            placeCommand.Execute();

            //assert
            Assert.IsTrue(tr.RobotStillOnTableTop(tt));
        }


        [TestMethod]
        public void ToyRobot_TableTop5Into5PlaceRobot3Into6AndRobotOnTableTopIsFalse()
        {
            //arrange
            //arrange
            TableTop tt = new TableTop(5, 5);
            ToyRobot tr = new ToyRobot();
            CommandModel cm = new CommandModel()
            {
                Command = Command.PLACE,
                Coordinate = new Coordinate(3, 6),
                Facing = Facing.NORTH
            };
            ICommandInterface placeCommand = new PlaceRobotCommand(cm, tr, tt);
            //act
            placeCommand.Execute();

            //assert
            Assert.IsFalse(tr.isRobotPlaced && tr.RobotStillOnTableTop(tt));
        }
    }
}
