using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class TemporaryOrder : BaseOrder
    {
        public DateTime OrdersEndDate{ get; set; }
        
        public DateTime? OrdersEndTime { get; set; }
    }
}
