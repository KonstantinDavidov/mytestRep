using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class LawersFeeAndCourtCosts
    {
        public bool IsEnabled { get; set; }
        public bool IsLawyerFee { get; set; }
        public bool IsCourtCosts { get; set; }
        public bool IsParty1Payer { get; set; }
        public Dictionary<string, string> LawyersFees
        {
            get;
            private set;
        }
        public LawersFeeAndCourtCosts()
        {
            LawyersFees = new Dictionary<string, string>();
        }
    }
}
