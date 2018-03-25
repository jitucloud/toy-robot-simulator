using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Model
{
    public class Coordinate
    {
        private int _xCoordinate;
        private int _yCoordinate;

    
        public int XCoordinate
        {
            get
            {
                return _xCoordinate;
            }
            set
            {
                if (value < 0)
                    throw new Exception("x-coordinate cannot be less than zero");
                else
                    _xCoordinate = value;
            }
        }

        
		public int YCoordinate
        {
            get
            {
                return _yCoordinate;
            }
            set
            {
                if (value < 0)
                    throw new Exception("y-coordinate cannot be less than zero");
                else
                    _yCoordinate = value;
            }
        }
        
		public Coordinate(int x, int y)
        {
            _xCoordinate = x;
            _yCoordinate = y;
        }

 
        public override string ToString()
        {
            return string.Format("{0}*{1}", _xCoordinate, _yCoordinate);
        }
        
        public Coordinate SetupNewCoordinates(int xSetupCoordinate, int ySetupCoordinate)
        {
            return new Coordinate(_xCoordinate + xSetupCoordinate, _yCoordinate + ySetupCoordinate);
        }
    }
}
