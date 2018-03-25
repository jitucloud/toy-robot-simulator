using System;
using System.Linq;
using ToyRobot.Model;
using ToyRobot.Enumeration;

namespace ToyRobot.Helper
{
    /// <summary>
    /// Command Parser class
    /// </summary>
    public static class CommandParser
    {
        /// <summary>
        /// Will Convert Input String to Command Model
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static CommandModel GetCommand(String inputString)
        {
            CommandModel commandModel = new CommandModel();
            Command command;
            if (inputString.StartsWith(Command.PLACE.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                int x = 0;
                int y = 0;
                var commandArray = inputString.Split(' ');
                if (commandArray != null && String.Equals(commandArray[0], Command.PLACE.ToString(), StringComparison.OrdinalIgnoreCase)
                    && commandArray.Count() == 2)
                {
                    var coordinateFacing = commandArray[1].Contains(',') ? commandArray[1].Split(',') : null;
                    if (coordinateFacing != null && coordinateFacing.Count() == 3)
                    {
                        commandModel.Command = Command.PLACE;
                        if (int.TryParse(coordinateFacing[0], out x) && int.TryParse(coordinateFacing[1], out y))
                            commandModel.Coordinate = new Coordinate(x, y);
                        else
                            return null;

                        Facing facing;
                        if (Enum.IsDefined(typeof(Facing), coordinateFacing[2].ToUpper()) && Enum.TryParse(coordinateFacing[2], true, out facing))
                            commandModel.Facing = facing;
                        else return null;

                        return commandModel;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            else if (Enum.TryParse(inputString, true, out command))
                commandModel.Command = command;
            else
                return null;
            return commandModel;
        }
    }
}
