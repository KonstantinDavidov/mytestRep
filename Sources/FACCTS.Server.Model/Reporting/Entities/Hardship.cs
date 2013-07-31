using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public enum Hardship
    {
        [Description("Other minor children")]
        OtherMinorChildren = 0,
        [Description("Extraordinary medical expenses")]
        ExtraordinaryMedicalExpenses = 1,
        [Description("Catastrophic losses")]
        CatastrophicLosses = 2
    }
}
