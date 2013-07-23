using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting
{
    public class PaymentItem
    {
        public string PaymentDescription {get; set;}
        public bool IsAttorneyFee { get; set; }
        public string PaymentFor { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDueDate { get; set; }
    }
}
