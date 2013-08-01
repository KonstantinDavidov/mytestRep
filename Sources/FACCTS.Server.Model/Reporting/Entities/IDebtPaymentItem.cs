using System;
namespace FACCTS.Server.Model.Reporting.Entities
{
    public interface IDebtPaymentItem
    {
        string Name { get; set; }
        DateTime PaymentDate { get; set; }
        FACCTS.Server.Model.Enums.ParticipantRole PaymentFor { get; set; }
    }
}
