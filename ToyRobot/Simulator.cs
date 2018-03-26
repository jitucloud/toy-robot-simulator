using System;
using ToyRobot.Commands;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot
{
    /// <summary>
    /// Simulator class
    /// </summary>
    public class Simulator
    {
        ToyRobot tr { get; set; }
        TableTop tt { get; set; }

        /// <summary>
        /// Simulator Ctor
        /// </summary>
        /// <param name="toyRobot"></param>
        /// <param name="tableTop"></param>
        public Simulator(ToyRobot toyRobot, TableTop tableTop)
        {
            this.tr = toyRobot;
            this.tt = tableTop;
        }

        /// <summary>
        /// Simulator Command Action Method
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        public ICommandInterface Action(CommandModel inputCommand)
        {
            if (tr.isRobotPlaced || inputCommand.Command == Command.PLACE)
            {
                if (inputCommand.Command == Command.PLACE)
                    return new PlaceRobotCommand(inputCommand, tr, tt);
                else if (inputCommand.Command == Command.MOVE)
                    return new MoveForwardCommand(tr, tt);
                else if (inputCommand.Command == Command.LEFT)
                    return new TurnLeftCommand(tr);
                else if (inputCommand.Command == Command.RIGHT)
                    return new TurnRightCommand(tr);
                else
                    throw new Exception("not a valid command");
            }
            else
            {
                throw new Exception("robot is not on the table");
            }
        }

        /// <summary>
        /// Will Report the current coordinates of Robot
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (tr.isRobotPlaced)
            {
                return tr.GetCurrentRobotPosition();
            }
            else
            {
                return "robot is not placed on table";
            }
        }
    }
}
