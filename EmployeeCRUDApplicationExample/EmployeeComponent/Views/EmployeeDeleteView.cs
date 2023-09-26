using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views
{
    public class EmployeeDeleteView
    {
        private Employees _employees = null;

        public EmployeeDeleteView(Employees employees)
        {
            _employees = employees;
        }

        public void RunDeleteView()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter id of empoloyee whose record you wish to delete");

            int id = Convert.ToInt32(Console.ReadLine());

            int index = _employees.Find(id);

            if (index != -1)
            {
                Employee employee = _employees[index];

                Console.WriteLine($"Are you sure you wish to delete employee with id({employee.Id})? (y/n)");

                ConsoleKey consoleKey = Console.ReadKey().Key;

                if(consoleKey == ConsoleKey.Y)
                {
                    _employees.Delete(index);

                }
                else if(consoleKey == ConsoleKey.N)
                {
                    Console.WriteLine("Record will not be deleted");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Incorrect key pressed.");
                    Console.ReadKey();
                }



                Console.ReadKey();
            }
            else
            {
                Console.Clear();

                Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());
                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeNotFoundMessage(id));

                Console.ReadKey();
            }
        }
    }
}
