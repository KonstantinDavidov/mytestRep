using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.OrderModels
{
    public class PermanentOrder : BaseOrder, IPermanentOrder
    {
        public bool IsExpire {get; set;}

        public DateTime? OrdersEndDate {get; set;}

        public DateTime? OrdersEndTime { get; set;}
    }
}
