using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversionDemo
{
    class Program
    {
        public struct ImperialMeasurement
        {
            public float feet;

            public ImperialMeasurement(float r)
            {
                this.feet = r;
            }

            //public static implicit operator ImperialMeasurement(int m)
            public static explicit operator ImperialMeasurement(int m)
            {
                float conversionResult = 3.28f * m;

                ImperialMeasurement temp = new ImperialMeasurement(conversionResult);

                return temp;
            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a whole number measurement in meters");

            int mm = Convert.ToInt16(Console.ReadLine());

            //ImperialMeasurement im = mm;  //--> Implicit version, produces the same output
            ImperialMeasurement im = (ImperialMeasurement)mm;

            Console.WriteLine($"The measurement of {mm} in meters is {im.feet} in feet");

            Console.ReadKey();
        }
    }
}
