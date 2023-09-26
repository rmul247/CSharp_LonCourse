using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeID = 0;
            string firstName = String.Empty;
            string lastName = String.Empty;
            decimal annualSalary = 0;
            char gender = '\0';
            bool isManager = false;

            Console.WriteLine("Please enter a unique ID for this employee");

            employeeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter employees first name");

            firstName = Console.ReadLine();

            Console.WriteLine("Enter employees surname");

            lastName = Console.ReadLine();

            Console.WriteLine("Enter employees annual salary");

            annualSalary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter employees gender. m/f");

            gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Employee is a manager. true/false");

            isManager = Convert.ToBoolean(Console.ReadLine());

            string genderTerm = (gender == 'f') ? "female" : "male";

            string managerNarrative = (isManager) ? "" : "not currently";

            string narrative = $"Employee with an ID of {employeeID} ";
            narrative += $"whose full name is {firstName} {lastName} ";
            narrative += $"is a {genderTerm} employee who is {managerNarrative} part of the management team.";
            narrative += $"\nThis employee has an annual salary of {annualSalary} Euro.";

            Console.Clear();

            Console.WriteLine(narrative);

            Console.ReadKey();

        }
    }
}
