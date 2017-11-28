using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drone
{
    public class Drone : FlyingObject
    {
        private bool lights = false;
        public void toggleLights()
        {
            lights = !lights;
            string lightsString = (lights) ? "on" : "off";
            Console.WriteLine("Lights are " + lightsString);
        }
        public void flashLights()
        {
            Console.WriteLine("Lights are flashed");
        }
        public void soundHorn(double duration)
        {
            Console.WriteLine("Horn is sounding");
            Thread.Sleep(Convert.ToInt32(duration * 1000));
            Console.WriteLine("Horn has finished sounding");
        }
        public void restart()
        {
            xCoordinates = 0;
            yCoordinates = 0;
            yBoundary = 0;
            xBoundary = 0;
        }
    }
}
