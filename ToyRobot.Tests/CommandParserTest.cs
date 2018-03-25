using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Helper;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot.Tests
{
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
        public void CommandParser_InputCommandCheckNegetiveCoordinatesIsNull()
        {
            var inputCommand = "Place -2,3,4";
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
