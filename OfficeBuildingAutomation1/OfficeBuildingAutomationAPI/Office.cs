using System;

namespace OfficeBuildingAutomationAPI
{
    public class Office
    {
        // 'private' restricts access to within the class
        private bool _IsLightOn = false;
        private bool _IsSecurityArmed = false;
        private int _OfficeId = 0;
        private OfficeBuildingFakeWebService _officeBuildingFakeWebService = null;
        private int _securityToken = 0;

        public Office()
        {
            _officeBuildingFakeWebService = new OfficeBuildingFakeWebService();
        }

        public bool IslightOn
        {
            get
            {
                return _IsLightOn;
            }
        }

        public bool IsSecurtiyArmed { get => _IsSecurityArmed; }
        //{
        //    get
        //    {
        //        return _IsSecurityArmed;
        //    }
        //}

        public int OfficeID { get => _OfficeId; }

        public void Login(int officeID, string userName, string password)
        {
            _securityToken = _officeBuildingFakeWebService.Login(officeID, userName, password);

            if (_securityToken > 0)
            {
                _IsLightOn = _officeBuildingFakeWebService.IsLightOn(_securityToken);
                _IsSecurityArmed = _officeBuildingFakeWebService.IsSecuritySystemArmed(_securityToken);
                _OfficeId = officeID;

            }
        }

        internal void ToggleLights()
        {
            if (_IsLightOn)
            {
                _officeBuildingFakeWebService.SwitchLightsOff(_securityToken);
                _IsLightOn = false;
            }
            else
            {
                _officeBuildingFakeWebService.SwitchLightsOn(_securityToken);
                _IsLightOn = true;
            }
        }

        internal void ToggleSecuritySystem()
        {
            if (_IsSecurityArmed)
            {
                _officeBuildingFakeWebService.DisarmSecuritySystem(_securityToken);
                _IsSecurityArmed = false;
            }
            else
            {
                _officeBuildingFakeWebService.ArmSecuritySystem(_securityToken);
                _IsSecurityArmed = true;
            }
        }

    }
}
