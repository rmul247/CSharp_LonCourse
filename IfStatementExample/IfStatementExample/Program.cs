using System;

namespace IfStatementExample
{
    class Program
    {
        static void Main()
        {
            decimal savingAccountBalance = 420.50m;
            decimal costOfBike = 1000m;
            bool canGetLoan = true;
            decimal maxLoanAmount = 600;

            if (savingAccountBalance >= costOfBike || canGetLoan && savingAccountBalance + maxLoanAmount >= costOfBike)
            {
                Console.WriteLine("You can buy the bike");
            }
            else
            {
                Console.WriteLine("You can't afford a new bike");
            }


            Console.ReadKey();
        }
    }
}
