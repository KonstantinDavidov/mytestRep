using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class AttachmentOrder : IDataTransferConvertible<FACCTS.Server.Model.DataModel.AttachmentOrder>
    {
        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.AttachmentOrder ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.AttachmentOrder()
            {
                Id = this.Id,
                OrderType = this.OrderType,
                XmlContent = this.XmlContent,
                ServerFileName = this.ServerFileName,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
