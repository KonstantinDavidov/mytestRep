using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class NoServiceFee
    {
        public bool IsOrdered { get; set; }
        public bool IsFeeWaiver { get; set; }
        public bool IsBasedOnViolence { get; set; }
    }
}
