using System;

namespace OperatorOverloadExample
{
    public class Rectangle
    {
        public int Width = 0;
        public int Height = 0;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // method-looking code to enable overloading of '+' operator
        // this code will be called when the '+' operator is applied between any two 
        // objects instantiated from the 'Rectangle' class
        public static Rectangle operator + (Rectangle rect1, Rectangle rect2)
        {
            Rectangle rectResult = new OperatorOverloadExample.Rectangle(rect1.Width + rect2.Width, rect1.Height + rect2.Height);

            return rectResult;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter height and width of rectangle 1");
            int height1 = Convert.ToInt32(Console.ReadLine());
            int width1 = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Enter height and width of rectangle 2");
            int height2 = Convert.ToInt32(Console.ReadLine());
            int width2 = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Rectangle testRect1 = new Rectangle(width1, height1);
            Rectangle testRect2 = new Rectangle(width2, height2);

            Rectangle combinedRectangle = testRect1 + testRect2;

            Console.WriteLine("Initial Rectangle sizes are:");
            Console.WriteLine($"Rectangle 1: ({width1}, {height1})");
            Console.WriteLine($"Rectangle 2: ({width2}, {height2})");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine($"Combined rectangle dimensions: ({combinedRectangle.Width}, {combinedRectangle.Height})");
        }
    }
}
