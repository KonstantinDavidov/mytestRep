using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class AttachmentOrder : IEntityWithId, IEntityWithState
    {
        public long MasterOrderId { get; set; }

        public virtual MasterOrder MasterOrder { get; set; }

        public AttachmentOrders OrderType { get; set; }

        public string XmlContent { get; set; }

        public string ServerFileName { get; set; }

        public long Id { get; set; }

        public ObjectState State { get; set; }
    }
}