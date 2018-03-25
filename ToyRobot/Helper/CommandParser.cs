using System;
using System.Linq;
using ToyRobot.Model;
using ToyRobot.Enumeration;

namespace ToyRobot.Helper
{
    public static class CommandParser
    {
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
                            throw new Exception("wrong command");

                        Facing facing;
                        if (Enum.TryParse(coordinateFacing[2], true, out facing))
                            commandModel.Facing = facing;
                        else throw new Exception("wrong facing string passed");
                        return commandModel;
                    }
                    else
                        throw new Exception("wrong coordinate-direction in place command :" + inputString);
                }
                else
                    throw new Exception("wrong parameter in input command :" + inputString);
            }
            else if (Enum.TryParse(inputString, true, out command))
                commandModel.Command = command;
            else
                throw new Exception("wrong parameter in input command :" + inputString);

            return commandModel;
        }
    }
}
