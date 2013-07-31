using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class HardshipItem
    {
        public Hardship Hardship { get; set; }
        public decimal PlantiffPaymentAmount { get; set; }
        public decimal RespondentPaymentAmount { get; set; }
        public decimal OtherPaymentAmount { get; set; }
        public DateTime PaymentEndDate { get; set; }
    }
}
