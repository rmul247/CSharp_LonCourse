using System;
using System.Configuration;

namespace MarsInfoApplication
{
    public class Constants
    {
        public const int SpeedOfLight = 300000;
    }


    public class Mars
    {
        public readonly int DistanceToMars = 0;

        public Mars()
        {
            // manually overridden as .NET Framework 
            //version is too old for ConfigurationManager to be installed

            //DistanceToMars = ConfigurationManager.AppSettings["DistanceToMars"];

            DistanceToMars = 225000000;
        }

        public int GetInfoTravelTime()
        {
            return DistanceToMars / Constants.SpeedOfLight;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Mars mars = new Mars();

            Console.WriteLine($"Time for info to travel from Earth to Mars is {mars.GetInfoTravelTime()} seconds");

            Console.ReadKey();
        }
    }
}
