using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EmployeeComponent.Data
{
    // Class Description
    // - on instantiation an ArrayList is created and the SeedData method is called
    //   - the ArrayList contains objects of type Employee
    //   - the SeedData method passes employee info to the EmployeeObjectFactory and adds the returned, newly instantiated Employee object to the ArrayList
    // - CRUD methods are also defined for Employee objects in the ArrayList
    // - an Employees-type object is made enumerable by returning an enumerable of the ArrayList if the Employees-type object is foreach-looped 
    public class Employees
    {
        ArrayList _employeeList = null;

        // constructor creates new ArrayList and calls SeedData to fill the ArrayList
        public Employees()
        {
            _employeeList = new ArrayList();
            SeedData();

        }

        // property that allows the instance of the Employees class to be array addressable
        // the data at the index of the ArrayList is returned
        // I think....
        public Employee this[int index]
        {
            get
            {
                return (Employee)_employeeList[index]; // explicit cast required as ArrayLists can be heterogenous
            }
            //set                                      // set not used, just included to show functionality
            //{
            //    _employeeList[index] = value;
            //}
        }

        // this method passes employee info to the EmployeeObjectFactory, and using the CreateNewEmployeeObject creates a new instance of the Employee class
        // this newly created Employee-type object is then added to the ArrayList using this classes Add() method
        private void SeedData()
        {
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Pascal", "Siakam", 100000, 'm', true));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("O.G.", "Anunoby", 80000, 'm', false));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Scottie", "Barnes", 70000, 'm', true));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Lana", "Del Rey", 200000, 'f', false));
        }

        // custom Add method to add each new Employee-type object to the ArrayList
        public void Add(Employee employee)
        {
            _employeeList.Add(employee);
        }

        // method to update the values of fields of the Employee-type object passed in as an argument
        public void Update(Employee employee, string firstName, string lastName, decimal annualSalary, char gender, bool isManager) 
        {
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.AnnualSalary = annualSalary;
            employee.Gender = gender;
            employee.IsManager = isManager;
        }

        // deletes the Employee object from the ArrayList at the specified index
        public void Delete(int index)
        {
            _employeeList.RemoveAt(index);
        }

        // finds the index of the Employee object in the ArrayList, if it is there
        public int Find(int id)
        {
            int count = 0;

            foreach(Employee employee in _employeeList)
            {
                if(employee.Id == id)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        // returns amount of Employee objects in the ArrayList
        public int Count()
        {
            return _employeeList.Count;
        }

        // returns an Enumerator for the ArrayList, when an Employees-type class is iterated over using the foreach statement
        public IEnumerator GetEnumerator()
        {
            return _employeeList.GetEnumerator();
        }
    }
}
