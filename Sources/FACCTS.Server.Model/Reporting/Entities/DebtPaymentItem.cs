using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class DebtPaymentItem : FACCTS.Server.Model.Reporting.Entities.IDebtPaymentItem
    {
        public string Name { get; set; }
        public ParticipantRole PaymentFor { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
