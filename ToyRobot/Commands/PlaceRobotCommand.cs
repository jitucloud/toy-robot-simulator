using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public class PlaceRobotCommand : IMoveInterface
    {
        CommandModel commandModel;
        ToyRobot tr;
        TableTop tt;

        public PlaceRobotCommand(CommandModel commandModel, ToyRobot toyRobot, TableTop tableTop)
        {
            this.commandModel = commandModel;
            this.tr = toyRobot;
            this.tt = tableTop;
        }
        public void Execute()
        {
            if (tt.IsRobotInTableTopRange(commandModel.Coordinate))
            {
                tr.robotCoordinates = commandModel.Coordinate;
                tr.robotDirection = commandModel.Facing;
                tr.isRobotPlaced = true;
            }
        }
    }
}
