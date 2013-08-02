using System;
namespace FACCTS.Server.Model.Reporting.Entities
{
    public interface IPermanentOrder
    {
        bool IsExpire { get; set; }
        DateTime? OrdersEndDate { get; set; }
        DateTime? OrdersEndTime { get; set; }
    }
}
