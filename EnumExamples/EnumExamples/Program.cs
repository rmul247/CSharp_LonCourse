using System;
using System.Linq;

namespace EnumExamples
{
    // Month enum is used as a bit flag, with each bit in a 12-bit integer corresponding to a month
    // the 'Flags' attribute is used to enable the return of all months with set bits only
    [Flags]
    public enum Month
    {
        Jan = 1,
        Feb = 2,
        Mar = 4,
        Apr = 8,
        May = 16,
        Jun = 32,
        Jul = 64,
        Aug = 128,
        Sep = 256,
        Oct = 512,
        Nov = 1024,
        Dec = 2048
    }

    public enum ReportType
    {
        Sum,
        Average,
        Min,
        Max
    }

    class Program
    {
        public static void ProcessMonthlyExpenditureData(Month month)
        {
            switch (month)
            {
                case Month.Jan:
                    Console.WriteLine("Processing data for Jan...");
                    Console.WriteLine($"The value of the month is {(int)month}");
                    break;
                case Month.Feb:
                    Console.WriteLine("Processing data for Feb...");
                    break;
                case Month.Mar:
                    Console.WriteLine("Processing data for Mar...");
                    break;
                case Month.Apr:
                    Console.WriteLine("Processing data for Apr...");
                    break;
                case Month.May:
                    Console.WriteLine("Processing data for May...");
                    break;
                case Month.Jun:
                    Console.WriteLine("Processing data for Jun...");
                    break;
                case Month.Jul:
                    Console.WriteLine("Processing data for Jul...");
                    break;
                case Month.Aug:
                    Console.WriteLine("Processing data for Aug...");
                    Console.WriteLine($"The value of the month is {(int)month}");
                    break;
                case Month.Sep:
                    Console.WriteLine("Processing data for Sep...");
                    break;
                case Month.Oct:
                    Console.WriteLine("Processing data for Oct...");
                    break;
                case Month.Nov:
                    Console.WriteLine("Processing data for Nov...");
                    break;
                case Month.Dec:
                    Console.WriteLine("Processing data for Dec...");
                    break;
                default:
                    throw new Exception("Invalid month");
            }
        }


        static void Main()
        {
            //ProcessMonthlyExpenditureData(Month.Jan);

            decimal[] data = new decimal[12]; // creating a (empty) decimal array ready for 12 values
                                              // since array is a reference type, 'data' is a reference to the new array object this means when PopulateMonthlyExpenditureData()
                                              //  is called, a copy of the reference/pointer is passed into() function is the same as the array instantiated here, albeit
                                              //  pointed to by two distinct variables/pointers

            PopulateMonthlyExpenditureData(data);   // calling method to populate the array, it's done manually here 
                                                    // but would most likely be some sort of database query

            Month months = Month.Jan | Month.Apr | Month.Jun | Month.Jul | Month.Aug | Month.Dec;   // initializing variable of enum type Month
                                                                                                    //  - because of the way the enum values were chosen the value here 
                                                                                                    //    has 1 bit representing each month e.g. 100011101001b = 2281d

            decimal[] reportData = GetReportData(months, data); // create new array to hold the return of the GetReportData method
                                                                // and call GetReportData with selected months and data array populated

            // call 'OutputReport()' function to write expenditure data to the console
            OutputReport(ReportType.Sum, months, reportData);
            OutputReport(ReportType.Average, months, reportData);
            OutputReport(ReportType.Min, months, reportData);
            OutputReport(ReportType.Max, months, reportData);

            Console.ReadKey();
        }

        public static void OutputReport(ReportType reportType, Month chosenMonths, decimal[] reportData)
        {
            // switch report type generated based on ReportType enum passed in as argument
            // LINQ functions (Sum,Average, etc.) are used here to abstract out maths operations on array values
            switch (reportType)
            {
                case ReportType.Sum:
                    Console.WriteLine($"Total expenditure for months, {chosenMonths} is {reportData.Sum()}");
                    break;
                case ReportType.Average:
                    Console.WriteLine($"Average expenditure for months, {chosenMonths} is {reportData.Average()}");
                    break;
                case ReportType.Min:
                    Console.WriteLine($"Minimum expenditure for months, {chosenMonths} is {reportData.Min()}");
                    break;
                case ReportType.Max:
                    Console.WriteLine($"Maximum expenditure for months, {chosenMonths} is {reportData.Max()}");
                    break;
                default:
                    throw new Exception("Invalid report type.");
            }
        }

        public static decimal[] GetReportData(Month months, decimal[] data)
        {
            int count = 0; // hold the index of the reportData array being filled
            int testMonthInclusion; // bitwise check to see if the month being 'foreach'-ed is set in the 'months' argument
                                    //  i.e. should month be reported on/should expenditure data be retrieved for that month

            int reportDataLength = CountBits((int)months); // use Kernighan's Algorithm to see how many months/'month bits' are 'set'

            decimal[] reportData = new decimal[reportDataLength]; // create new array, with size informed by Kern.'s bit check above

            int index; // variable to store the position that the tested month is in if it passes the test, in the array passed in as the 'data' argument

            // foreach iterates through each month sequentially, then checks if that month(a.k.a. item) is
            // part of the months argument passed in to the function
            foreach (var item in Enum.GetValues(typeof(Month))) // item is a month of enumerable type Month (e.g. Jan=1, Aug=128, Nov=1024, etc...)
            {
                testMonthInclusion = (int)months & (int)item; // bitwise 'AND' check to see if the month (item) being 'foreach'-ed is set in the 'months' argument
                                                              // both months and item are cast/unboxed to the int type so that bitwise maths can be performed

                if (testMonthInclusion > 0) // if test is passed i.e if the month item describes is 'set' in the months variable
                {
                    index = (int)Math.Round(Math.Log((int)item, 2)); // Log(base2) of item gets the exponent of the specific month, essentially getting the 
                                                                     //  array index for the corresponding data of that month in the expenditure data array
                                                                     //  casting and maths operations are to end up with an integer

                    reportData[count] = data[index]; // copy expenditure data from the original array into reportData

                    count++; // increment count so that next loop the next position in the reportData array can recieve copied expenditure data
                }
            }

            return reportData; // return an array containing expenditure data only for the months that passed the 'testMonthInclusion' test
        }

        public static int CountBits(int value)
        {
            //Brian Kernighan's Algorithm
            //Counts the number of set bits

            int count = 0;

            while (value != 0)
            {
                count++;
                value &= value - 1;
            }

            return count;
        }

        public static void PopulateMonthlyExpenditureData(decimal[] data)
        {
            data[0] = 5000;     //Jan expenditure
            data[1] = 3000.50m; //      .
            data[2] = 4000.3m;  //      .
            data[3] = 2000;     //Apr expenditure
            data[4] = 3500;     //      .
            data[5] = 4000.2m;  //      .
            data[6] = 1000;     //      .
            data[7] = 500;      //Aug expenditure
            data[8] = 600;      //      .
            data[9] = 6000;     //      .
            data[10] = 3000;    //      .
            data[11] = 10000;   //Dec expenditure
        }
    }
}
