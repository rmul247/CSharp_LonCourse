using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal loanAmount = 0;
            decimal loanAmountCopy = 0;

            Console.WriteLine("Enter a loan amount:");

            loanAmount = Convert.ToDecimal(Console.ReadLine());

            loanAmountCopy = loanAmount;

            Console.WriteLine($"loanAmount: {loanAmount}, loanAmountCopy = {loanAmountCopy}");

            Console.ReadKey();

            loanAmount = loanAmount + 600;

            Console.WriteLine();
            // loanAmount will change but loanAmountCopy will stay the same because decimals are value types
            // i.e. they staore their data directly, as opposed to referance types (like strings/objects, etc
            // which store a reference to the data
            // if the underlying data is chanced, two different references will both change as they are referring to
            // the same initial (and now changed) data
            Console.WriteLine($"After adding 600, loanAmount = {loanAmount}, loanAmountCopy = {loanAmountCopy}");

            Console.ReadKey();
        }
    }
}
