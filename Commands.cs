using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public static class Commands
    {
        public static bool isCommand(string command)
        {
            string firstLetter = command.Substring(0, 1);
            if(firstLetter != "S" && firstLetter != "B" &&firstLetter != "P" &&firstLetter != "R" &&firstLetter != "D" &&firstLetter != "T" &&firstLetter != "F" &&firstLetter != "A" &&
                firstLetter != "H" &&firstLetter != "M")
                return false;
            return true;
        }
        public static void processDroneCommand(string command, Drone drone, out bool shutDownReceived)
        {
            shutDownReceived = false;
            CommandNames commandName = CommandNames.Unassigned;
            string firstLetter = command.Substring(0, 1);
            if (firstLetter == "S")
                commandName = CommandNames.Start;
            if (firstLetter == "B")
                commandName = CommandNames.Boundary;
            if (firstLetter == "P")
                commandName = CommandNames.InitiaPosition;
            if (firstLetter == "R")
                commandName = CommandNames.Restart;
            if (firstLetter == "D")
                commandName = CommandNames.Shutdown;
            if (firstLetter == "T")
                commandName = CommandNames.ToggleLights;
            if (firstLetter == "F")
                commandName = CommandNames.FlashLights;
            if (firstLetter == "A")
                commandName = CommandNames.Alert;
            if (firstLetter == "H")
                commandName = CommandNames.Home;
            if (firstLetter == "M")
                commandName = CommandNames.Move;

            if (commandName == CommandNames.Start)
            {
                drone.started = true;
                Console.WriteLine("Drone is started");
            }
            else if (commandName == CommandNames.Boundary)
            {
                drone.xBoundary = Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[0]);
                drone.yBoundary = Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[1]);
                Console.WriteLine("Boundary set to X = " + drone.xBoundary + " and Y = " + drone.yBoundary);
            }
            else if (commandName == CommandNames.InitiaPosition)
            {
                drone.xInitialCoordinates = drone.xCoordinates = Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[0]);
                drone.yInitialCoordinates = drone.yCoordinates = Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[1]);
                Console.WriteLine("Initial Position set to X = " + drone.xInitialCoordinates + " and Y = " + drone.yInitialCoordinates);
            }
            else if (commandName == CommandNames.ToggleLights)
            {
                if (FlyingActions.checkStarted(drone))
                    drone.toggleLights();
            }
            else if (commandName == CommandNames.FlashLights)
            {
                if (FlyingActions.checkStarted(drone))
                    drone.flashLights();
            }
            else if (commandName == CommandNames.Alert)
            {
                if (FlyingActions.checkStarted(drone))
                    drone.soundHorn(Convert.ToDouble(command.Substring(1, command.Length - 1)));
            }
            else if (commandName == CommandNames.Home)
            {
                if (FlyingActions.checkStarted(drone))
                    FlyingActions.flyHome(drone);
            }
            else if (commandName == CommandNames.Move)
            {
                if (FlyingActions.checkStarted(drone))
                {
                    bool reachedBoundary;
                    FlyingActions.fly(drone, Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[1]), Convert.ToDouble(command.Substring(1, command.Length - 1).Split(',')[0]), out reachedBoundary);
                    if (reachedBoundary)
                    {
                        drone.soundHorn(0.5);
                        drone.soundHorn(0.5);
                        drone.soundHorn(0.5);
                    }
                }
            }
            else if (commandName == CommandNames.Restart)
            {
                drone.restart();
            }
            else if (commandName == CommandNames.Shutdown)
            {
                shutDownReceived = true;
            }

        }
    }
    public enum CommandNames
    {
        Unassigned,
        Start,
        Boundary,
        InitiaPosition,
        Restart,
        Shutdown,
        ToggleLights,
        FlashLights,
        Alert,
        Home,
        Move
    }
}
