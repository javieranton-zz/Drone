using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public static class FlyingActions
    {
        public static void fly(FlyingObject flyingObject, double compassHeading, double duration, out bool reachedBoundary)
        {
            reachedBoundary = false;
            if (checkStarted(flyingObject))
            {
                flyingObject.xCoordinates += Math.Sin(compassHeading * Math.PI/180) * 0.5 * duration;
                flyingObject.yCoordinates += Math.Cos(compassHeading * Math.PI / 180) * 0.5 * duration;
                if(flyingObject.xCoordinates > flyingObject.xBoundary)
                {
                    flyingObject.xCoordinates = flyingObject.xBoundary;
                    reachedBoundary = true;
                }
                if (flyingObject.xCoordinates < 0)
                {
                    flyingObject.xCoordinates = 0;
                    reachedBoundary = true;
                }
                if (flyingObject.yCoordinates > flyingObject.yBoundary)
                {
                    flyingObject.yCoordinates = flyingObject.yBoundary;
                    reachedBoundary = true;
                }
                if (flyingObject.yCoordinates < 0)
                {
                    flyingObject.yCoordinates = 0;
                    reachedBoundary = true;
                }
                Console.WriteLine("New Position: X: " + flyingObject.xCoordinates + "; Y = " + flyingObject.yCoordinates);
            }
        }
        public  static void flyHome(FlyingObject flyingObject)
        {
            if (checkStarted(flyingObject))
            {
                flyingObject.xCoordinates = flyingObject.xInitialCoordinates;
                flyingObject.yCoordinates = flyingObject.yInitialCoordinates;
            }
        }
        public static void start(FlyingObject flyingObject)
        {
            flyingObject.started = true;
        }
        public static bool checkStarted(FlyingObject flyingObject)
        {
            if (flyingObject.started && flyingObject.xBoundary != 0 && flyingObject.yBoundary != 0)
                return true;
            else
            {
                Console.WriteLine("Systems is not started");
                return false;
            }
        }
    }
}
