using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enumeration;

namespace ToyRobot.Model
{
    /// <summary>
    /// Command Model
    /// </summary>
    public class CommandModel
    {
        public Command Command { get; set; }
        public Coordinate Coordinate { get; set; }
        public Facing Facing { get; set; }
    }
}
