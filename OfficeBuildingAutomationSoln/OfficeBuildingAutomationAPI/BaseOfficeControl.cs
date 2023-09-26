using System;

namespace OfficeBuildingAutomationAPI
{
    public class BaseOfficeControl
    {
        // 'internal' restrics access to within the assembly
        // 'protected' restricts access to classes that inherit BaseOfficeControl class
        //   - inheriting classes can be external to the assembly
        protected internal Office[] Offices = null;

        public BaseOfficeControl(Office[] offices)
        {
            Offices = offices;

        }

        // 'virtual' keyword means function can be overridden by inheriting class, if needed but not necessary
        public virtual void LightToggleButton_Press()
        {
            foreach (Office office in Offices)
            {
                office.ToggleLights();
            }
        }

        public virtual void SecurityToggleButton_Press()
        {
            foreach (Office office in Offices)
            {
                office.ToggleSecuritySystem();
            }
        }

        // 'protected' means derived classes can access this method
        //'private' keyword means code within class can access it
        //  - code from derived classes that are NOT in the assembly cannot access this method
        private protected void LogInfo(string line)
        {
            Console.WriteLine(line);
        }
    }
}
