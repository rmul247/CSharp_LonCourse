using System;

namespace OfficeBuildingAutomationAPI
{
    public class TestOfficeControl
    {
        private BaseOfficeControl _officeControl = null;

        public TestOfficeControl(BaseOfficeControl officeControl)
        {
            _officeControl = officeControl;
        }

        public void LightToggleButton_Press()
        {
            Console.WriteLine("Testing light toggle button...\n");

            _officeControl.LightToggleButton_Press();
            LogLightTestStatus();
        }

        public void SecuritySystemToggleButton_Press()
        {
            Console.WriteLine("Testing security system toggle button...\n");

            _officeControl.SecurityToggleButton_Press();
            LogSecurityTestStatus();
        }

        private void LogLightTestStatus()
        {
            Console.WriteLine("Test Offices: " + GetTestOfficesAsString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Light toggle test passed");
            Console.ResetColor();
        }

        private void LogSecurityTestStatus()
        {
            Console.WriteLine("Test Offices: " + GetTestOfficesAsString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Security toggle test passed");
            Console.ResetColor();
        }

        private string GetTestOfficesAsString()
        {
            string officeIds = String.Empty;

            // Access to "Offices" field allowed because ìn 'BaseOfficeControl' class the array Offices[] is
            //  declared with the 'internal' keyword, allowing classes/methods within the assembly to access it
            // If it had been declared just with 'protected' then it would not be accessible by this class as
            //  this class does not inherit from the 'BaseOfficeControl' class
            // An object of type 'BaseOfficeControl' IS passed into the constructor of this class, the relevant methods of 
            //  the BaseOfficeControl class are then wrapped in the relevant methods of the TestOfficeControl class
            // The 'protected' access modifier would allow access to a derived class that could access this field using the 'base' keyword
            // TestOfficeControl is not an Office Control, therefore it does not inherit from the BaseOfficeControl class, but access to
            // the Offices[] array is still required, this is why 'internal' was chosen as a keyword
            foreach (Office office in _officeControl.Offices)
            {
                officeIds += office.OfficeID.ToString() + ",";
            }

            return officeIds.TrimEnd(',');
        }

    }
}
