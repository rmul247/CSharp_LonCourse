using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    public class Student
    {
        // member variables (underscore usually means they are to be private)
        int _stuId = 0;
        string _firstName = String.Empty;
        string _lastName = String.Empty;
        decimal _loanAmount = 0;
        char _gender = '\0';
        bool _isNew = false;

        // constructor - initializes Student class member variables of the new 
        // object instantiated from the class at runtime
        public Student(int stuId, string firstName, string lastName, decimal loanAmount, char gender, bool isNew)
        {
            _stuId = stuId;
            _firstName = firstName;
            _lastName = lastName;
            _loanAmount = loanAmount;
            _gender = gender;
            _isNew = isNew;

        }

        public string StudentData()
        {
            string studentData = $"stuId: {_stuId} \nfirst name: {_firstName} \nloan amount: {_loanAmount}";

            return studentData;
        }

        public void UpdateLoanAmount(decimal loanAmount)
        {
            _loanAmount = loanAmount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int stuId = 0;
            string firstName = string.Empty;
            string lastName = string.Empty;
            decimal loanAmount = 0;
            char gender = '\0';
            bool isNew = false;

            Console.WriteLine("Enter student ID: ");
            stuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter first name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
            lastName = Console.ReadLine();

            Console.WriteLine("Enter loan amount: ");
            loanAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter gender (m/f): ");
            gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Student is new? (true/false): ");
            isNew = Convert.ToBoolean(Console.ReadLine());

            Student student = new Student(stuId, firstName, lastName, loanAmount, gender, isNew);

            Console.Clear();

            Student studentCopy = student;

            Console.WriteLine("Student data  " + student.StudentData());
            Console.WriteLine();

            Console.WriteLine("Student copy data  " + studentCopy.StudentData());
            Console.WriteLine();

            Console.WriteLine("Please update the students loan amount");
            student.UpdateLoanAmount(Convert.ToDecimal(Console.ReadLine()));

            string dividerText = "After loan update";

            Console.WriteLine(new String('-', dividerText.Length));
            Console.WriteLine(dividerText);
            Console.WriteLine(new String('-', dividerText.Length));

            Console.WriteLine("Student data  " + student.StudentData());

            Console.WriteLine();

            Console.WriteLine("Student copy data  " + studentCopy.StudentData());

        }
    }
}
