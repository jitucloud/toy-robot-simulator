using System;
using ToyRobot.Model;

namespace ToyRobot
{
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

        public TableTop(int topRightXCoordinates, int topRightYCoordinates)
        {
            _topRightCoordinates = _topRightCoordinates.SetupNewCoordinates(topRightXCoordinates, topRightYCoordinates);
        }
                

        public String CalculateTableDimentions()
        {
            return String.Format("Table Area:" + _topRightCoordinates.ToString());
        }

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
