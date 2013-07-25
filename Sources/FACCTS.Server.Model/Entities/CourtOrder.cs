using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtOrder: IEntityWithId, IEntityWithState
    {
        public long Id { get; set; }

        public CourtOrdersTypes OrderType { get; set; }

        public long? ParentOrderId { get; set; }

        public CourtOrder ParentOrder { get; set; }

        public virtual ICollection<CourtOrder> Attachments { get; set; }

        public string XMLContent { get; set; }

        public bool IsSigned { get; set; }

        public string ServerFileName { get; set; }

        public long HearingId { get; set; }

        public virtual Hearing Hearing { get; set; }

        public ObjectState State { get; set; }
    }
}