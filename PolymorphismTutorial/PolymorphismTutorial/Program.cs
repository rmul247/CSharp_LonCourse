using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDerived p = new ProductDerived();

            Console.WriteLine(p.GetPrice());
            Console.WriteLine(((ProductBase)p).GetPrice());
        }
    }

    public abstract class ProductBase
    {
        public virtual decimal GetPrice()
        {
            return 10.00m;
        }

        public abstract string GetProductName();
    }

    public class ProductDerived : ProductBase
    {
        public new decimal GetPrice()
        {
            return base.GetPrice() + 2;
        }

        public override sealed string GetProductName()
        {
            return "ProductDerived";
        }
    }

    public class ProductAnotherDerived : ProductDerived
    {
        public new decimal GetPrice()
        {
            return base.GetPrice() + 3;
        }

        public override string GetProductName()
        {
            return "ProductAnotherDerived";
        }

    }

}
