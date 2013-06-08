using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum Depts
    {
        [Display(Name="G2")]
        G2 = 0,
        [Display(Name = "G3")]
        G3,
        [Display(Name = "G4")]
        G4
    }
}
