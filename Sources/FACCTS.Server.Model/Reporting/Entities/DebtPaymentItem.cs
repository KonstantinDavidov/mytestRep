using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class DebtPaymentItem
    {
        public string Name { get; set; }
        public string PaymentTo { get; set; }
        public string PaymentFrom { get; set; }
        public string PaymentFor { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
