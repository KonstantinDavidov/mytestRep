using System;
namespace FACCTS.Server.Model.Reporting.Entities
{
    public interface ITemporaryOrder
    {
        DateTime OrdersEndDate { get; set; }
        DateTime? OrdersEndTime { get; set; }
    }
}
