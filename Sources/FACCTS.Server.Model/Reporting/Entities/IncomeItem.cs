using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class IncomeItem
    {
        public Designation ParentRole { get; set; }
        public decimal GrossMonthlyIncome { get; set; }
        public decimal NetMonthlyIncome { get; set; }
        public decimal ImputedIncome { get; set; }
        public bool IsRecievedByTANF { get; set; }
    }
}
