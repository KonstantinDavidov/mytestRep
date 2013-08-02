using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.OrderModels
{
    public class TemporaryOrder : BaseOrder, ITemporaryOrder
    {
        public DateTime OrdersEndDate{ get; set; }
        
        public DateTime? OrdersEndTime { get; set; }
    }
}
