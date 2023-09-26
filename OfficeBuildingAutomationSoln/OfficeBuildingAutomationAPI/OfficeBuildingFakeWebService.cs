using System;

namespace OfficeBuildingAutomationAPI
{
    internal class OfficeBuildingFakeWebService
    {
        //'internal' keyword meand this class and its methods can only be accessed from code
        // within the same assembly, but not from code in another assembly
        // i.e. OfficeBuildingAutomationAPI = YES, OfficeBuildingAutomation = NO
        // each project in the solution will be compiled into a seperate assembly

        private static int _securityToken = 0;

        internal OfficeBuildingFakeWebService()
        {
            _securityToken++;
        }

        internal int Login(int officeID, string userName, string password)
        {
            return _securityToken;
        }

        internal bool IsLightOn(int securityToken)
        {
            return false;
        }

        internal bool IsSecuritySystemArmed(int securityToken)
        {
            return false;
        }

        internal void SwitchLightsOn(int securityToken)
        {
            //Code to switch lights on goes here
        }

        internal void SwitchLightsOff(int securityToken)
        {
            //Code to switch lights off goes here
        }

        internal void ArmSecuritySystem(int securityToken)
        {
            //Code to arm the security system goes here
        }

        internal void DisarmSecuritySystem(int securityToken)
        {
            //Code to disarm the security system goes here
        }
    }
}
