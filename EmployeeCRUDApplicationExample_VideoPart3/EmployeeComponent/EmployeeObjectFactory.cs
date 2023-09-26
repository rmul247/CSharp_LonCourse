using EmployeeComponent.Data;
using EmployeeComponent.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeComponent
{
    // Class Description:
    // - used to create new instance of the Employee class for the Employees class (SeedData() method)
    // - also creates/returns new instance of EmployeeRecordsView by passing an Employees object from the Main method to the EmployeeRecordsView constructor
    public static class EmployeeObjectFactory
    {
        // method that is called by SeedData() method in the Employees class
        // the "second way" demonstrates that the properties of a classes setters can be used to instantiate an object
        public static Employee CreateNewEmployeeObject(string firstName, string lastName, decimal annualSalary, char gender, bool isManager)
        {
            // first way would pass the arguments to a parameterised constructor in the Employee class
            //
            //return new Employee(firstName, lastName, annualSalary, gender, isManager);

            // second way
            //  takes advantage of the setter methods in the Employee properties to initialize the member variables upon instantiation
            //  because of this the parameterless constructor is called (this is the constructor that increments the static _nextId variable)
            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                AnnualSalary = annualSalary,
                Gender = gender,
                IsManager = isManager
            };

        }

        // passes an Employees-type object to the EmployeeRecordsView constructor and
        // returns a newly instantiated EmployeeRecordsView-type object
        public static EmployeeRecordsView EmployeeRecordsViewObject(Employees employees)
        {
            return new EmployeeRecordsView(employees);
        }
    }
}
