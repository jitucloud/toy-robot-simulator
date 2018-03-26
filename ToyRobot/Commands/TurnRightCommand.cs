using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enumeration;

namespace ToyRobot.Commands
{
    /// <summary>
    /// Turn Right Command class
    /// </summary>
    public class TurnRightCommand : ICommandInterface
    {
        ToyRobot tr;

        public TurnRightCommand(ToyRobot toyRobot)
        {
            this.tr = toyRobot;
        }

        /// <summary>
        /// Turn Right Command Execute Implementation
        /// </summary>
        public void Execute()
        {
            switch (tr.robotDirection)
            {
                case Facing.NORTH:
                    tr.robotDirection = Facing.EAST;
                    break;

                case Facing.WEST:
                    tr.robotDirection = Facing.NORTH;
                    break;

                case Facing.SOUTH:
                    tr.robotDirection = Facing.WEST;
                    break;

                case Facing.EAST:
                    tr.robotDirection = Facing.SOUTH;
                    break;
            }
        }
    }
}
