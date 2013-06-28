using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class CAPROSEntry
    {
        public CARPOSEntryType CARPOSEntryType { get; set; }
        public Dictionary<string, string> LawEnforcementAgencies { get; set; }
        public NoServiceFee NoServiceFee { get; set; }
    }
}
