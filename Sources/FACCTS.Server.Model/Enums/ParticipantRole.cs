using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum ParticipantRole
    {
        [Description("Protected")]
        PPSC = 0,
        [Description("Restrained")]
        RESPER = 1,
        [Description("Additional Protected")]
        APPSC = 2,
        [Description("Agent For Service")]
        AFS = 3
    }
}
