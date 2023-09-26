using System;
using System.IO;
using BasicFileHandlingCSharp;

namespace PlayingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            try
            {
                WriteHeadingToScreen();
                
                Console.WriteLine("Please enter a name for your file");

                string fileName = Console.ReadLine();

                Console.WriteLine();

                string[] lines = new string[3];

                TextFileFunctions textFileFunctions = new TextFileFunctions(fileName);

                do
                {
                    Console.WriteLine($"Please add {(count > 0 ? "another line" : "a line")} to file, '{fileName}'");
                    lines[count] = Console.ReadLine();
                    count++;
                }
                while (count < 3);

                textFileFunctions.WriteTextToFile(lines);

                Console.Clear();

                WriteHeadingToScreen();

                Console.Write(textFileFunctions.ReadFile());

            }
            catch (IOException ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private static void WriteHeadingToScreen()
        {
            Console.WriteLine("Basic .NET Cross Platform File Handling");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }
    }
}