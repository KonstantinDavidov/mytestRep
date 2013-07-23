using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum AddressType
    {
        [Description("Billing")]
        BILL = 0,
        [Description("Business")]
        BUS = 1,
        [Description("Collection")]
        COL = 2,
        [Description("General Delivery")]
        GEN = 3,
        [Description("Home")]
        HOM = 4,
        [Description("International")]
        INT = 5,
        [Description("Mailing")]
        MAIL = 6,
        [Description("Military A.P.O. Box")]
        MILAPO = 7,
        [Description("Military F.P.O. Box")]
        MILFPO = 8,
        [Description("N/A")]
        NONE = 9,
        [Description("P.O. Box")]
        POBOX  = 10,
        [Description("Transient")]
        TRA = 11,
        [Description("Unknown")]
        UNK = 12,
        [Description("Warrant")]
        WARR = 13
    }
}
