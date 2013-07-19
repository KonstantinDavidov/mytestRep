using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class MasterOrder : IDataTransferConvertible<FACCTS.Server.Model.DataModel.MasterOrder>
    {
        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.MasterOrder ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.MasterOrder()
            {
                Id = this.Id,
                OrderType = this.OrderType,
                AttachmentOrders = this.AttachmentOrder.Where(x => x.IsDirty).Select(x => x.ToDTO()).ToArray(),
                XMLContent = this.XMLContent,
                IsSigned = this.IsSigned,
                ServerFileName = this.ServerFileName,
                State = (FACCTS.Server.Model.DataModel.ObjectState) (int)this.ChangeTracker.State,
            };
        }
    }
}
