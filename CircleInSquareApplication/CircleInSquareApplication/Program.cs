using System;

namespace CircleInSquareApplication
{
    class Program
    {
        
        public struct CircleInSquare : IPattern
        {
            public double Radius;
            public char InnerSymbol;
            public char OuterSymbol;

            public CircleInSquare(double radius, char innerSymbol, char outerSymbol)
            {
                Radius = radius;
                InnerSymbol = innerSymbol;
                OuterSymbol = outerSymbol;
            }

            public void WriteMemberValuesToScreen() {
                Console.WriteLine($"Radius: {Radius}, Inner Symbol: '{InnerSymbol}', Outer Symbol: '{OuterSymbol}'");

            }

            public void Draw()
            {
                double radiusInner = Radius - 0.5;
                double radiusOuter = Radius + 0.5;

                Console.WriteLine();

                for (double y = Radius; y >= -Radius; --y)
                {
                    for (double x = -Radius; x < radiusOuter; x += 0.5)
                    {
                        double value = x * x + y * y;

                        if (value >= radiusInner * radiusInner)
                        {
                            Console.Write(OuterSymbol);
                            System.Threading.Thread.Sleep(30);
                        }
                        else
                        {
                            Console.Write(InnerSymbol);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public interface IPattern
        {
            void Draw();
        }

        static void Main()
        {
            Console.WriteLine("Enter circle radius: ");

            double radius = Convert.ToDouble(Console.ReadLine());

            CircleInSquare circleInSquare1 = new CircleInSquare(radius, '0', '1');
            CircleInSquare circleInSquare2 = new CircleInSquare(radius, '&', '@');
            CircleInSquare circleInSquare3 = new CircleInSquare(radius, '^', '$');

            CircleInSquare[] circlesArray = new CircleInSquare[3];

            circlesArray[0] = circleInSquare1;

            circlesArray[1] = circleInSquare2;
            circlesArray[1].Radius = radius / 2;

            circlesArray[2] = circleInSquare3;
            circlesArray[2].Radius = radius / 3;

            foreach (CircleInSquare circleInSquare in circlesArray)
            {
                circleInSquare.Draw();
            }

            CircleInSquare circleInSquareItem = circlesArray[0];

            circleInSquareItem.Radius = radius / 2;

            circleInSquareItem.Draw();
            circlesArray[0].Draw();

            Console.ReadKey();
        }

    }
}
