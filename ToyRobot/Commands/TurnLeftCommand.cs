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
    /// Turn Left Command class
    /// </summary>
    public class TurnLeftCommand : ICommandInterface
    {
        ToyRobot tr;
        public TurnLeftCommand(ToyRobot tr)
        {
            this.tr = tr;
        }
        /// <summary>
        /// Turn Left Command Execute Implementation
        /// </summary>
        public void Execute()
        {
            switch (tr.robotDirection)
            {
                case Facing.NORTH:
                    tr.robotDirection = Facing.WEST;
                    break;

                case Facing.WEST:
                    tr.robotDirection = Facing.SOUTH;
                    break;

                case Facing.SOUTH:
                    tr.robotDirection = Facing.EAST;
                    break;

                case Facing.EAST:
                    tr.robotDirection = Facing.NORTH;
                    break;
            }
        }
    }
}
