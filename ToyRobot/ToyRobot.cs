using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot
{
    /// <summary>
    /// ToyRobot class
    /// </summary>
    public class ToyRobot
    {
        public Coordinate robotCoordinates;
        public Facing? robotDirection;
        public bool isRobotPlaced = false;

        /// <summary>
        /// ToyRobot Empty constructor
        /// </summary>
        public ToyRobot()
        {

        }

        /// <summary>
        /// ToyRobot Parameter Constructor
        /// </summary>
        /// <param name="cr"></param>
        /// <param name="facing"></param>
        public ToyRobot(Coordinate cr, Facing facing)
        {
            this.robotCoordinates = cr;
            this.robotDirection = facing;
        }

        /// <summary>
        /// Get Robot Current Position
        /// </summary>
        /// <returns></returns>
        public string GetCurrentRobotPosition()
        {
            if (robotCoordinates != null && robotDirection != null)
            {
                return string.Format("X-Coordinate {0} : Y-Coordinate {1} : Direction {2}", robotCoordinates.XCoordinate, robotCoordinates.YCoordinate, robotDirection.ToString());
            }
            else return null;
        }

        /// <summary>
        /// To Check if Robot is Still on Table
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public bool RobotStillOnTableTop(TableTop tt)
        {
            if (tt != null)
            {
                return (robotCoordinates.XCoordinate >= 0)
                && (robotCoordinates.XCoordinate <= tt.TopRightCoordinates.XCoordinate)
                && (robotCoordinates.YCoordinate >= 0)
                && (robotCoordinates.YCoordinate <= tt.TopRightCoordinates.YCoordinate);
            }
            else return false;
        }
    }
}
