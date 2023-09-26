using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeComponent.Views
{
    // Class Description:
    // - responsible for writing the column headings and the employee data to the console
    // - the constructor receives an Employees-type object from the Main() method and extracts data from each Employee in the employees object
    public class EmployeeRecordsView
    {
        private Employees _employees = null;

        // assigns the employees argument to the private member variable
        public EmployeeRecordsView(Employees employees)
        {
            _employees = employees;
        }

        public void RunRecordsView()
        {
            // write header info
            Console.WriteLine(EmployeeCommonOutputText.GetColumnHeadings());
            Console.WriteLine();

            // using the fact that the employees object is enumerable via the ArrayList being enumerable
            // the object can be treated as an enumerable list
            foreach (Employee employee in _employees)
            {
                // output formatted employee info for each employee in the "IEnumerable Array List"-like '_employees' object
                Console.WriteLine(employee.GetEmployeeInformation());
            }
        }
    }
}
