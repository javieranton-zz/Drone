using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    class Program
    {
        static string command;
        static Drone drone;
        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {
            drone = new Drone();
            command = string.Empty;
            getCommand();

            Console.WriteLine("END");
            Console.WriteLine("Rerun? Y/N ");
            string rerun = Console.ReadLine();
            if (rerun.ToUpper() == "Y")
            {
                Console.Clear();
                run();
            }
        }
        static void getCommand()
        {
            try
            {
                bool shutDownReceived = false;
                while (!shutDownReceived)
                {
                    Console.WriteLine("Please enter command");
                    command = Console.ReadLine();
                    Console.Clear();
                    if (string.IsNullOrEmpty(command) || !Commands.isCommand(command))
                    {
                        Console.WriteLine("Command not recognized. Please try again");
                        getCommand();
                    }
                    else
                    {
                        Commands.processDroneCommand(command, drone, out shutDownReceived);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error parsing input string");
                getCommand();
            }
        }
    }
}
