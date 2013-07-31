using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class ChildSupportItem
    {
        public long ChildId { get; set; }
        public string PaidToPersonName { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
