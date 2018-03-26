using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Helper;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot.Tests
{
    /// <summary>
    /// command parser test class
    /// </summary>
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void CommandParser_InputCommandIsEmpty()
        {
            var inputCommand = string.Empty;
            Assert.IsNull(CommandParser.GetCommand(inputCommand));
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckInvalidCommandIsNull()
        {
            var inputCommand = "Hello 2,3,north";
            Assert.IsNull(CommandParser.GetCommand(inputCommand));
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckValidPlaceCommandIsNotNull()
        {
            var inputCommand = "place 2,3,north";
            Assert.IsNotNull(CommandParser.GetCommand(inputCommand));
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckValidMoveCommandIsEqualToMove()
        {
            var inputCommand = "move";
            Assert.AreEqual(CommandParser.GetCommand(inputCommand).Command, Command.MOVE);
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckValidLeftCommandIsEqualToLeft()
        {
            var inputCommand = "left";
            Assert.AreEqual(CommandParser.GetCommand(inputCommand).Command, Command.LEFT);
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckValidLeftCommandIsNotEqualToRight()
        {
            var inputCommand = "left";
            Assert.AreNotEqual(CommandParser.GetCommand(inputCommand).Command, Command.RIGHT);
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckNegetiveCoordinatesIsNull()
        {
            var inputCommand = "Place -2,3,north";
            Assert.IsNull(CommandParser.GetCommand(inputCommand));
        }

        [TestMethod]
        public void CommandParser_InputCommandCheckCoordinatesAreValid()
        {
            var inputCommand = "Place 2,3,south";
            Assert.IsTrue(CommandParser.GetCommand(inputCommand).Coordinate.Equals(new Coordinate(2, 3)));
        }

        [TestMethod]
        public void CommandParser_CheckCommandFacingIsInvalid()
        {
            var inputCommand = "Place 2,3,4";
            Assert.IsNull(CommandParser.GetCommand(inputCommand));
        }

        [TestMethod]
        public void CommandParser_CheckCommandFacingIsNorth()
        {
            var inputCommand = "Place 2,3,north";
            Assert.AreEqual(CommandParser.GetCommand(inputCommand).Facing, Facing.NORTH);
        }
    }
}
