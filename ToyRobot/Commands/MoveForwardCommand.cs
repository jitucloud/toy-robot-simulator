using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    /// <summary>
    /// Move Command 
    /// </summary>
    public class MoveForwardCommand : ICommandInterface
    {
        ToyRobot tr;
        TableTop tt;
        public MoveForwardCommand(ToyRobot toyRobot, TableTop tableTop)
        {
            this.tr = toyRobot;
            this.tt = tableTop;
        }

        /// <summary>
        /// Move Command Execute Implementation
        /// </summary>
        public void Execute()
        {
            Coordinate tempCoordinate = tr.robotCoordinates;
            switch (tr.robotDirection)
            {
                case Facing.NORTH:
                    tr.robotCoordinates = tt.IsRobotInTableTopRange(tempCoordinate.SetupNewCoordinates(0, 1)) ? tr.robotCoordinates.SetupNewCoordinates(0, 1) : tr.robotCoordinates;
                    break;

                case Facing.EAST:
                    tr.robotCoordinates = tt.IsRobotInTableTopRange(tempCoordinate.SetupNewCoordinates(0, 1)) ? tr.robotCoordinates.SetupNewCoordinates(1, 0) : tr.robotCoordinates;
                    break;

                case Facing.SOUTH:
                    tr.robotCoordinates = tt.IsRobotInTableTopRange(tempCoordinate.SetupNewCoordinates(0, 1)) ? tr.robotCoordinates.SetupNewCoordinates(0, -1) : tr.robotCoordinates;
                    break;

                case Facing.WEST:
                    tr.robotCoordinates = tt.IsRobotInTableTopRange(tempCoordinate.SetupNewCoordinates(0, 1)) ? tr.robotCoordinates.SetupNewCoordinates(-1, 0) : tr.robotCoordinates;
                    break;
            }

        }
    }
}
