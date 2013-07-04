using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class Party
    {
        public string Name { get; set; }
        public FACCTS.Server.Model.Enums.ParticipantRole ParticipantRole { get; set; }
        public Designation Designation { get; set; }
        public bool IsPresent { get; set; }
        public bool IsSworn { get; set; }
        public bool HasAttorney { get; set; }
        public string Parent { get; set; }
    }
}
