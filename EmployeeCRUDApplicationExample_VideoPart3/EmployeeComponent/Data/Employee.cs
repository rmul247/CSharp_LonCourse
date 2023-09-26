using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeComponent.Data
{
    // Class Description
    // - template for Employee objects
    //  - constructor increments the static _nextId variable and then assigns that value to _id
    //  - a new Employee object is then created with this unique (and sequentially incremented) Id
    // - GetEmployeeInformation() method converts the data in an Employee-type object to a string
    public class Employee
    {
        // static int _nextId "remembers" its value, so each new instance gets an incremented value (as per the operation in the constructor)
        private static int _nextId = 0;
        private int _id = 0;

        /************************************************
         * can be removed due to ObjectFactory implementation
         * the properties are used to set the values on instantiation
         * 
        private string _firstName = String.Empty;
        private string _lastName = string.Empty;
        private decimal _annualSalary = 0;
        private char _gender = '\0';
        private bool _isManager = false;
         *
         *
         ***********************************************/

        public int Id {
            get
            { 
                return _id; 
            } 
        }

        // this is called auto-implemented properties
        // public properties can be written like this if...
        // if using an ObjectFactory these properties aer used to set/initialize the values of the member variables on instantiation,
        // private member variables that are usually initialized with values within the parameterized constructor can (also) be removed
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }

        public Employee()
        {
            _nextId++;
            _id = _nextId;
        }

        /**************************************************************
         * the parameterised constructor can be removed if new object is created in the "second way" as seen in EmployeeObjectFactory
         * 
        public Employee(string firstName, string lastName, decimal annualSalary, char gender, bool isManager) : this()
        {
            _firstName = firstName;
            _lastName = lastName;
            _annualSalary = annualSalary;
            _gender = gender;
            _isManager = isManager;
        }
         *
         *
         *************************************************************/

        // method to create string of employee data in the desired format
        public string GetEmployeeInformation()
        {
            string employeeInformation = $"{Id.ToString().PadRight(6)}\t{FirstName.PadRight(15)}\t{LastName.PadRight(15)}\t{AnnualSalary.ToString().PadRight(15)}\t{Gender.ToString().PadRight(6)}\t{IsManager.ToString().PadRight(7)}\n";

            return employeeInformation;
        }
    }
}
