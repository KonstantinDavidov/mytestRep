using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum IdentificationIDType
    {
        [Description("Drivers License Number")]
        DriversLicenseNumber = 0,
        [Description("Air Force Serial")]
        AirForceSerial,
        [Description("Alien Registration")]
        AlienRegistration,
        [Description("Army Registration")]
        ArmyRegistration,
        [Description("National Guard Serial")]
        NationalGuardSerial,
        [Description("Air National Guard Serial")]
        AirNationalGuardSerial,
        [Description("US Coast Guard Serial")]
        USCoastGuardSerial,
        [Description("Marine Corps Serial")]
        MarineCorpsSerial,
        [Description("Mariners Document ID")]
        MarinersDocumentID,
        [Description("Navy Serial")]
        NavySerial,
        [Description("Originating Police Agency ID")]
        OriginatingPoliceAgencyID,
        [Description("Passport")]
        Passport,
        [Description("Personal ID")]
        PersonalID,
        [Description("Port Security Card")]
        PortSecurityCard,
        [Description("Veterans Administration Card")]
        VeteransAdministrationCard,
        [Description("FBI Number")]
        FBINumber,
        [Description("Social Security Number")]
        SocialSecurityNumber,
        [Description("State ID Fingerprint")]
        StateIDFingerprint,
    }
}
