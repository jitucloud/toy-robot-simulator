using System;
using ToyRobot.Model;

namespace ToyRobot
{
    /// <summary>
    /// Table Top Class
    /// </summary>
    public class TableTop
    {
        private Coordinate _topRightCoordinates = new Coordinate(0, 0);
        private Coordinate _bottomLeftCoordinates = new Coordinate(0, 0);

        public Coordinate TopRightCoordinates
        {
            get { return _topRightCoordinates; }
            set { _topRightCoordinates = value; }
        }


        public Coordinate BottomLeftCoordinates
        {
            get { return _bottomLeftCoordinates; }
            set { _bottomLeftCoordinates = value; }
        }

        /// <summary>
        /// TableTop ctor
        /// </summary>
        /// <param name="topRightXCoordinates"></param>
        /// <param name="topRightYCoordinates"></param>
        public TableTop(int topRightXCoordinates, int topRightYCoordinates)
        {
            _topRightCoordinates = _topRightCoordinates.SetupNewCoordinates(topRightXCoordinates, topRightYCoordinates);
        }
                
        /// <summary>
        /// To Check if Placed Robot is in TableTop Range
        /// </summary>
        /// <param name="robotCoordinates"></param>
        /// <returns></returns>
        public bool IsRobotInTableTopRange(Coordinate robotCoordinates)
        {
            if (robotCoordinates != null)
            {
                return (robotCoordinates.XCoordinate >= 0)
                && (robotCoordinates.XCoordinate <= TopRightCoordinates.XCoordinate)
                && (robotCoordinates.YCoordinate >= 0)
                && (robotCoordinates.YCoordinate <= TopRightCoordinates.YCoordinate);
            }
            else return false;
        }
    }
}
