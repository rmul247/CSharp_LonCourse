using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTutorial_SwitchTo_.NET5
{
    interface IApartment
    {
        int Id { get; set; }
        int Floor { get; set; }
        double SizeInSquareMetres { get; set; }
    }
}
