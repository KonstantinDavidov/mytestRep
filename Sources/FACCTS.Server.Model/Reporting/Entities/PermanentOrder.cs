using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class PermanentOrder : BaseOrder
    {
        public bool IsExpire {get; set;}

        public DateTime? OrdersEndDate {get; set;}

        public DateTime? OrdersEndTime { get; set;}
    }
}
