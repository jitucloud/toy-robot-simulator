using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Model
{
    /// <summary>
    /// Coordinates class
    /// </summary>
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


        /// <summary>
        /// Override of ToString for Coordinates
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}*{1}", _xCoordinate, _yCoordinate);
        }


        /// <summary>
        /// Override of Equals for Coordinates
        /// </summary>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;

            Coordinate p = (Coordinate)obj;
            return this.XCoordinate == p.XCoordinate && this.YCoordinate == p.YCoordinate;
        }

        /// <summary>
        /// Setup New Coordinates
        /// </summary>
        /// <param name="xSetupCoordinate"></param>
        /// <param name="ySetupCoordinate"></param>
        /// <returns></returns>
        public Coordinate SetupNewCoordinates(int xSetupCoordinate, int ySetupCoordinate)
        {
            return new Coordinate(_xCoordinate + xSetupCoordinate, _yCoordinate + ySetupCoordinate);
        }
    }
}
