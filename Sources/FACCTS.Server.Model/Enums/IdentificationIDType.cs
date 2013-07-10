using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum IdentificationIDType
    {
        [Description("Drivers License Number")]
        DLN = 0,
        [Description("Air Force Serial")]
        AF = 1,
        [Description("Alien Registration")]
        AR = 2,
        [Description("Army serial")]
        AS,
        [Description("National Guard Serial")] 
        NGS, //Clarify
        [Description("Air National Guard Serial")]
        ANGS, //Clarify
        [Description("US Coast Guard Serial")]
        CG,
        [Description("Marine Corps Serial")]
        MC,
        [Description("Mariners Document ID")]
        MD,
        [Description("Navy Serial")]
        NS,
        [Description("Originating Police Agency ID")]
        OA,
        [Description("Passport")]
        PP,
        [Description("Personal ID")]
        PI,
        [Description("Port Security Card")]
        PS,
        [Description("Veterans Administration Claim")]
        VA,
        [Description("FBI Number")]
        FBN,
        [Description("Social Security Number")]
        SSN,
        [Description("State Identification (fingerprint)")]
        SID,
        [Description("Criminal Identification (fingerprint)")]
        CII,
        [Description("Royal Canadian Mounted Police ID")]
        MP,
        [Description("Canadian Social Insurance")]
        CI
        
    }
}
