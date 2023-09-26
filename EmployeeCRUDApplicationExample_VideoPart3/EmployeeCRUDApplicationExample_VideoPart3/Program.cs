using System;
using EmployeeComponent;
using EmployeeComponent.Data;
using EmployeeComponent.Views;

namespace EmployeeCRUDApplicationExample_VideoPart3
{
    // Class Description:
    // - Home of the Main method
    //  - Instantiates a new Employees-type object (an ArrayList of Employee type objects)
    //  - Passes the Employees-type object to the EmployeeObjectFactory, which returns a new instance of an EmployeeRecordsView object
    //  - Writes the header text to the console
    //  - Calls RunRecordsView method of the EmployeeRecordsView object to iterate an Enumerable of the ArrayList of Employee objects and
    //    write the Employee-type objects data to the console
    class Program
    {
        
        static void Main(string[] args)
        {
            Employees employees = new Employees(); // initializes employees variable that will call Employees constructor creates and populates an
                                                   // ArrayList with newly instantiated Employee-type objects, and returns a newly instantiated object

            // passes the newly created Employees-type object employees to the EmployeeObjectFactory, into EmployeeRecordsViewObject method,
            // which in turn passes the Employees-type object into the EmployeeRecordsView constructor
            // a newly instantiated object of type EmployeeRecordsView is returned
            EmployeeRecordsView employeeRecordsView = EmployeeObjectFactory.EmployeeRecordsViewObject(employees);


            // EmployeeCommonOutputText is a class that contains strings and headers and line formatting
            // the GetApplicatinHeading method builds a header string and returns it, so it will be written here
            Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

            // use RunRecordsView method to iterate through the Employees-type object and write the employee data to the console
            // for each Employee-type object of the Employees-type object
            employeeRecordsView.RunRecordsView();

            Console.ReadKey();

        }

    }
}
