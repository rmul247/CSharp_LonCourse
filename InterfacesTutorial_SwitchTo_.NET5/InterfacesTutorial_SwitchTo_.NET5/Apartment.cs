using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTutorial_SwitchTo_.NET5
{
    class Apartment : IApartment, IDimensionMetric, IDimensionImperial
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public double SizeInSquareMetres { get; set; }

        double IDimensionMetric.GetSize()
        {
            return SizeInSquareMetres;
        }

        //returns size converted to square feet
        double IDimensionImperial.GetSize()
        {
            return Math.Round(SizeInSquareMetres * 10.746, 2) ;
        }
    }
}
