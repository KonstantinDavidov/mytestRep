using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class DebtItem
    {
        public decimal TotalDebt { get; set; }
        public decimal AmountOfPayments { get; set; }
        public Designation PayTo { get; set; }
        public Designation PaidBy { get; set; }
    }
}
