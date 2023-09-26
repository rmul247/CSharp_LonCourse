using System;
using OfficeBuildingAutomationAPI;


namespace OfficeBuildingAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Office office1 = new Office();
            Office office2 = new Office();
            Office office3 = new Office();

            Office[] offices = new Office[3];

            office1.Login(1001, "Admin", "password");
            office2.Login(1002, "Admin", "password");
            office3.Login(1003, "Admin", "password");

            offices[0] = office1;
            offices[1] = office2;
            offices[2] = office3;

            WriteInstructionHeader();

            RemoteDeviceOfficeControl officeControl = new RemoteDeviceOfficeControl(offices);

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();

                WriteInstructionHeader();

                if (key == ConsoleKey.L)
                {
                    officeControl.LightToggleButton_Press();
                }
                else if (key == ConsoleKey.S)
                {
                    officeControl.SecurityToggleButton_Press();
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please press 'L' to toggle lights\nPress 'S' to toggle security system\nPress 'Spacebar' to exit");
                }
            }
            
        }

        private static void WriteInstructionHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nToggle lights: [L]\nToggleSecurity System: [S]\nEnd Application: [Spacebar]");

            Console.ResetColor();

            Console.Write("\n\n***STATUS***\n\n");
        }

    }
}
