using System;

namespace OfficeBuildingAutomationAPI
{
    public class RemoteDeviceOfficeControl : BaseOfficeControl
    {
        public RemoteDeviceOfficeControl(Office[] offices) : base(offices)
        {
            LogLightStatus();
            LogSecuritytatus();
        }


        // 'public' because we want code outside the assembly to access these methods
        public override void LightToggleButton_Press()
        {
            base.LightToggleButton_Press();

            LogLightStatus();
            LogSecuritytatus();

        }

        public override void SecurityToggleButton_Press()
        {
            base.SecurityToggleButton_Press();

            LogLightStatus();
            LogSecuritytatus();

        }

        private void LogLightStatus()
        {
            string status = String.Empty;

            foreach (Office office in base.Offices)
            {
                status = (office.IslightOn) ? "on" : "off";
                base.LogInfo($"Remote Control Device: Lights for office:{office.OfficeID} is switched {status}");
            }

            Console.WriteLine();
        }

        private void LogSecuritytatus()
        {
            string status = String.Empty;

            foreach (Office office in base.Offices)
            {
                status = (office.IsSecurtiyArmed) ? "armed" : "disarmed";
                base.LogInfo($"Remote Control Device: Secruity for office:{office.OfficeID} is {status}");
            }

            Console.WriteLine();
        }

    }
}
