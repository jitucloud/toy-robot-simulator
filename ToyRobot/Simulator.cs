using System;
using ToyRobot.Commands;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot
{
    public class Simulator
    {
        ToyRobot tr { get; set; }
        TableTop tt { get; set; }

        public Simulator(ToyRobot toyRobot, TableTop tableTop)
        {
            this.tr = toyRobot;
            this.tt = tableTop;
        }

        public IMoveInterface Action(CommandModel inputCommand)
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

        public string Report()
        {
            return tr.GetCurrentRobotPosition();
        }
    }
}
