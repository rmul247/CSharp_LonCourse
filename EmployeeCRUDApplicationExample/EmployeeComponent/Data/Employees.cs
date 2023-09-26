using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EmployeeComponent.Data
{
    public class Employees
    {
        ArrayList _employeeList = null;

        public Employees()
        {
            _employeeList = new ArrayList();
            SeedData();

        }

        public Employee this[int index]
        {
            get
            {
                return (Employee)_employeeList[index];
            }
        }

        private void SeedData()
        {
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Pascal", "Siakam", 100000, 'm', true));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("O.G.", "Anunoby", 80000, 'm', false));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Scottie", "Barnes", 70000, 'm', true));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Lana", "Del Rey", 200000, 'f', false));
        }

        public void Add(Employee employee)
        {
            _employeeList.Add(employee);
        }

        public void Update(Employee employee, string firstName, string lastName, decimal annualSalary, char gender, bool isManager) 
        {
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.AnnualSalary = annualSalary;
            employee.Gender = gender;
            employee.IsManager = isManager;
        }

        public void Delete(int index)
        {
            _employeeList.RemoveAt(index);
        }

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

        public int Count()
        {
            return _employeeList.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return _employeeList.GetEnumerator();
        }
    }
}
