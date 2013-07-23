using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseNoteStatus
    {
        [Description("Private")]
        Private = 0,
        [Description("Public")]
        Public = 1
    }
}
