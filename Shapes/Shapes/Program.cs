using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawShapes();
            Console.ReadKey();

          
        }


        public static void DrawShapes()
        {
            Shape shape = null;

            do
            {
                Console.Clear();
                Console.WriteLine("[1] Triangle");
                Console.WriteLine("[2] Circle");
                Console.WriteLine("[3] Rectange");
                Console.WriteLine("[4] All");

                ConsoleKey input = Console.ReadKey().Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        shape = new Triangle();
                        break;
                    case ConsoleKey.D2:
                        shape = new Circle();
                        break;
                    case ConsoleKey.D3:
                        shape = new Rectangle();
                        break;
                    case ConsoleKey.D4:
                        shape = new Shape();
                        break;

                }

                shape?.Draw();

            } 
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
    }


    public class Shape
    {
        public virtual void Draw()
        {
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Circle(),
                new Triangle()
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine();

                shape.Draw();
            }
        }
    }

    /*
              ^
             ^ ^
            ^ ^ ^
           ^ ^ ^ ^ 
     
     */
    public class Triangle : Shape
    {
        public override void Draw()
        {
            int n = 9;

            Console.WriteLine();

            for (int i = 1; i <= n; i++) // i = what line the triangle is on
            {
                for (int x = 1; x <= n - i; x++) // how many "spaces" before start drawing
                {
                    Console.Write(" ");

                }
                for (int j = 1; j <= i; j++) // how many "^" to draw and where
                {
                    Console.Write("^" + " ");
                }
                Console.WriteLine();
            }
        }

    }

    public class Rectangle : Shape
    {
        private int _width;
        private int _hieght;
        private int _locationX;
        private int _locationY;

        private ConsoleColor _borderColor;

        public override void Draw()
        {
            _width = 20;
            _hieght = 5;
            _locationX = 1;
            _locationY = 5;
            _borderColor = ConsoleColor.Green;

            Console.ForegroundColor = _borderColor;
            Console.CursorTop = _locationY;
            Console.CursorLeft = _locationX;

            string s = "╔";
            string space = "";
            string temp = "";

            for (int i = 0; i < _width; i++)
            {
                space += " ";
                s += "═";
            }

            for (int j = 0; j < _locationX; j++)
            {
                temp += " ";
            }

            s += "╗" + "\n";

            for (int i = 0; i < _hieght; i++)
            {
                s += temp + "║" + space + "║" + "\n";
            }

            s += temp + "╚";

            for (int i = 0; i < _width; i++)
            {
                s += "═";
            }

            s += "╝" + "\n";

            Console.Write(s);
            Console.ResetColor();

        }

    }

    public class Circle : Shape
    {

        public override void Draw()
        {
            double radius;
            double thickness = 0.4;
            ConsoleColor borderColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = borderColor;
            char symbol = '*';

            radius = 10;

            Console.WriteLine();
            double rln = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rln * rln && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}