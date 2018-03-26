using System;
using ToyRobot.Model;
using ToyRobot.Helper;
using ToyRobot.Enumeration;

namespace ToyRobot
{
    /// <summary>
    /// Main Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry Point for the simulator
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ToyRobot tr = new ToyRobot();
            TableTop tp = new TableTop(5, 5);
            Simulator simulator = new Simulator(tr, tp);

            Console.WriteLine("*********welcome to toy robot on a table of 5*5 **************");
            Console.WriteLine("Valid commands to place on table: PLACE X,Y,NORTH|SOUTH|EAST|WEST (example: place 1,2,north)");
            Console.WriteLine("Valid commands to move on table: MOVE|LEFT|RIGHT|REPORT|EXIT");

            bool keepRunning = true;
            while (keepRunning)
            {
                String inputString = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputString))
                {
                    if (String.Equals(Command.EXIT.ToString(), inputString, StringComparison.OrdinalIgnoreCase))
                    {
                        keepRunning = false;
                        Console.WriteLine("robot existing the table : press any key again to exit");
                        Console.ReadLine();
                    }
                    else
                    {
                        try
                        {
                            CommandModel commandModel = CommandParser.GetCommand(inputString);
                            if (commandModel != null)
                            {
                                if (commandModel.Command == Command.REPORT)
                                    Console.WriteLine(simulator.Report());
                                else
                                {
                                    simulator.Action(commandModel).Execute();
                                    Console.WriteLine(simulator.Report());
                                }
                            }
                            else
                            {
                                Console.WriteLine("command not accepted : " + inputString);
                                Console.WriteLine("Valid commands to place on table: PLACE X,Y,NORTH|SOUTH|EAST|WEST (example: place 1,2,north)");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("log : " + e.Message.ToString());
                        }
                    }
                }
                else
                    Console.WriteLine("entered input string is null of empty");
            }
        }
    }
}
