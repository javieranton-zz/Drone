using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class FlyingObject
    {
        public FlyingObject()
        {
            xCoordinates = 0;
            yCoordinates = 0;
            xInitialCoordinates = 0;
            yInitialCoordinates = 0;
        }
        public double xCoordinates { get; set; }
        public double yCoordinates { get; set; }
        public double xInitialCoordinates { get; set; }
        public double yInitialCoordinates { get; set; }
        public double xBoundary { get; set; }
        public double yBoundary { get; set; }
        public bool started { get; set; }
    }
}
