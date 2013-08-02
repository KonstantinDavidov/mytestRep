using System;
namespace FACCTS.Server.Model.OrderModels
{
    public interface ITemporaryOrder
    {
        DateTime OrdersEndDate { get; set; }
        DateTime? OrdersEndTime { get; set; }
    }
}
