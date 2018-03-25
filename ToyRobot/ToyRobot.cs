using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enumeration;
using ToyRobot.Model;

namespace ToyRobot
{
    public class ToyRobot
    {
        public Coordinate robotCoordinates;
        public Facing? robotDirection;
        public bool isRobotPlaced = false;
        public ToyRobot()
        {

        }
        public ToyRobot(Coordinate cr, Facing facing)
        {
            this.robotCoordinates = cr;
            this.robotDirection = facing;
        }
        public string GetCurrentRobotPosition()
        {
            if (robotCoordinates != null && robotDirection != null)
            {
                return string.Format("X-Coordinate {0} : Y-Coordinate {1} : Direction {2}", robotCoordinates.XCoordinate, robotCoordinates.YCoordinate, robotDirection.ToString());
            }
            else return null;
        }

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
