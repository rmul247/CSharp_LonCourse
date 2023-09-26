using System;
using System.Collections.Generic;

namespace InterfacesTutorial_SwitchTo_.NET5

{
    class Program
    {
        static void Main()
        {
            /* Part 1 Code
            IList<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            Navigation(employees);

            Console.ReadKey();
            */

            /* Part 2 Code*/
            Apartment apartment = new Apartment()
            {
                Id = 1,
                Floor = 2,
                SizeInSquareMetres = 68
            };

            IDimensionImperial dimensionImperial = apartment;
            IDimensionMetric dimensionMetric = apartment;


            Console.WriteLine($"Apartment size (square feet): {dimensionImperial.GetSize()} ft\u00B2");
            Console.WriteLine($"Apartment size (square metres): {dimensionMetric.GetSize()} m\u00B2");

            Console.ReadKey();
        }

        private static void SeedData(IList<IEmployee> employees)
        {
            ChiefExecutiveOfficer chiefExecutiveOfficer = new ChiefExecutiveOfficer();

            chiefExecutiveOfficer.Id = 1;
            chiefExecutiveOfficer.JobTitle = "CEO";
            chiefExecutiveOfficer.FirstName = "James";
            chiefExecutiveOfficer.LastName = "Jenkins";
            chiefExecutiveOfficer.AnnualSalary = 200000;
            chiefExecutiveOfficer.HighestQualification = "Masters Degree";
            chiefExecutiveOfficer.Gender = 'm';
            chiefExecutiveOfficer.OfficeId = "E120";
            chiefExecutiveOfficer.JoinDate = new DateTime(2018, 1, 12);
            chiefExecutiveOfficer.SecretaryId = 43;
            chiefExecutiveOfficer.PersonalAssistant = 102;

            employees.Add(chiefExecutiveOfficer);

            Manager projectManager = new ProjectManager();

            projectManager.Id = 2;
            projectManager.JobTitle = "Project Manager";
            projectManager.FirstName = "Bob";
            projectManager.LastName = "Jones";
            projectManager.AnnualSalary = 100000;
            projectManager.HighestQualification = "Honours Degree";
            projectManager.Gender = 'm';
            projectManager.OfficeId = "D017";
            projectManager.JoinDate = new DateTime(2015, 4, 1);
            projectManager.SecretaryId = 110;
            projectManager.Id = 2;

            employees.Add(projectManager);

            Manager safetyManager = new SafetyManager();

            safetyManager.Id = 3;
            safetyManager.JobTitle = "Safety Manager";
            safetyManager.FirstName = "Jane";
            safetyManager.LastName = "Summers";
            safetyManager.AnnualSalary = 100000;
            safetyManager.HighestQualification = "Honours Degree";
            safetyManager.Gender = 'f';
            safetyManager.OfficeId = "D018";
            safetyManager.JoinDate = new DateTime(2016, 2, 3);
            safetyManager.SecretaryId = 145;

            employees.Add(safetyManager);

            Employee craneOperator = new CraneOperator();

            craneOperator.Id = 4;
            craneOperator.JobTitle = "Crane Operator";
            craneOperator.FirstName = "Sam";
            craneOperator.LastName = "Drake";
            craneOperator.AnnualSalary = 50000;
            craneOperator.HighestQualification = "Bachelor's Degree";
            craneOperator.Gender = 'm';
            craneOperator.JoinDate = new DateTime(2012, 5, 7);

            employees.Add(craneOperator);

            Employee electrician = new Electrician();

            electrician.Id = 5;
            electrician.JobTitle = "Electrician";
            electrician.FirstName = "James";
            electrician.LastName = "Ross";
            electrician.AnnualSalary = 45000;
            electrician.HighestQualification = "Bachelor's Degree";
            electrician.Gender = 'm';
            electrician.JoinDate = new DateTime(2013, 1, 16);

            employees.Add(electrician);

            Employee electrician2 = new Electrician();

            electrician2.Id = 6;
            electrician2.JobTitle = "Electrician";
            electrician2.FirstName = "Henry";
            electrician2.LastName = "Sanders";
            electrician2.AnnualSalary = 45000;
            electrician2.HighestQualification = "Bachelor's Degree";
            electrician2.Gender = 'm';
            electrician2.JoinDate = new DateTime(2017, 1, 16);

            employees.Add(electrician2);

        }

        private static void WriteHeading()
        {
            Console.WriteLine("The Construction Company");
            Console.WriteLine("------------------------");
            Console.WriteLine();
        }

        private static void WriteEmployeeInformationToScreen(IEmployee employee)
        {
            Console.Clear();

            WriteHeading();

            Console.WriteLine(employee.GetBasicInformation());

            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
            Console.WriteLine(employee.GetAdditionalInformation());

        }

        private static void Navigation(IList<IEmployee> employees)
        {
            int counter = 0;

            while (true)
            {
                if (counter < 0)
                {
                    counter = employees.Count - 1;
                }

                if (counter > employees.Count - 1)
                {
                    counter = 0;
                }

                WriteEmployeeInformationToScreen(employees[counter]);

                ConsoleKey consoleKey = Console.ReadKey().Key;

                if (consoleKey == ConsoleKey.RightArrow)
                {
                    counter++;
                }
                else if (consoleKey == ConsoleKey.LeftArrow)
                {
                    counter--;
                }
                else if (consoleKey == ConsoleKey.Spacebar)
                {
                    break;
                }


            }
        }

    }

    public abstract class Employee : IEmployee
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string HighestQualification { get; set; }

        public string GetAdditionalInformation()
        {
            return $"Highest Qualification: {HighestQualification}";
        }

        public virtual string GetBasicInformation()
        {
            return $"Id: {Id}\nJobTitle: {JobTitle}\nFirstName: {FirstName}\nLastName: {LastName}\nAnnualSalary: {AnnualSalary}\n";
        }

        public int GetFullYearsWorked()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan span = DateTime.Now.Subtract(JoinDate);

            int years = zeroTime.Add(span).Year - 1;

            return years;
        }
    }

    public interface IEmployee
    {
        int Id { get; set; }
        string JobTitle { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal AnnualSalary { get; set; }
        char Gender { get; set; }
        DateTime JoinDate { get; set; }
        string HighestQualification { get; set; }
        string GetBasicInformation();
        int GetFullYearsWorked();
        string GetAdditionalInformation()
        {
            return $"JoinDate: {JoinDate.ToString("dd MM yyyy")}\nGender: {Gender}";
        }

    }
    public class CraneOperator : Employee
    {
        private decimal GetDangerPayIncrease()
        {
            return 0.04m;
        }

        public override decimal AnnualSalary { get => base.AnnualSalary * (1 + GetDangerPayIncrease()); set => base.AnnualSalary = value; }

    }

    public class Electrician : Employee
    {


    }

    public class DryWallInstaller : Employee
    {

    }

    public interface IManager
    {
        string OfficeId { get; set; }
        int SecretaryId { get; set; }

    }

    public abstract class Manager : Employee, IManager
    {
        public string OfficeId { get; set; }
        public int SecretaryId { get; set; }

        public override string GetBasicInformation()
        {
            return base.GetBasicInformation() + $"\nOfficeId: {OfficeId}\nSecretaryId: {SecretaryId}\n";
        }

    }
    public class ProjectManager : Manager
    {

    }

    public class SafetyManager : Manager
    {

    }

    public interface IChiefExecutiveOfficer
    {
        int PersonalAssistant { get; set; }

    }

    public class ChiefExecutiveOfficer : Manager, IChiefExecutiveOfficer
    {
        public int PersonalAssistant { get; set; }

        public override string GetBasicInformation()
        {
            return base.GetBasicInformation() + $"\nPersonal Assistant: {PersonalAssistant}\n";
        }
    }
}
