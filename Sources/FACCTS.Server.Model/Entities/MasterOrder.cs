using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class MasterOrder: BaseEntity
    {
        public virtual CaseHistory ParentHistoryNote { get; set; }

        public MasterOrders OrderType { get; set; }

        public virtual ICollection<AttachmentOrder> AttachmentOrders { get; set; }

        public string XMLContent { get; set; }

        public bool IsSigned { get; set; }

        public string ServerFileName { get; set; }
    }
}