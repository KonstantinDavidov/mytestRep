using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class MasterOrderConfiguration : EntityTypeConfiguration<MasterOrder>
    {
        public MasterOrderConfiguration()
        {
            ToTable(DbConsts.MASTER_ORDERS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(o => o.Id);

            HasRequired(o => o.ParentHistoryNote).WithOptional(h => h.MasterOrder);
            HasMany(o => o.AttachmentOrders).WithRequired(a => a.MasterOrder).HasForeignKey(a => a.MasterOrderId).WillCascadeOnDelete(true);

            Property(o => o.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(o => o.OrderType).HasColumnName(DbConsts.MASTER_ORDERS_ORDER_TYPE_COLUMN_NAME);
            Property(o => o.XMLContent).HasColumnName(DbConsts.MASTER_ORDERS_XML_CONTENT_COLUMN_NAME).HasColumnType("xml");
            Property(o => o.IsSigned).HasColumnName(DbConsts.MASTER_ORDERS_IS_SIGNED_COLUMN_NAME);
            Property(o => o.ServerFileName).HasColumnName(DbConsts.MASTER_ORDERS_SERVER_FILE_NAME_COLUMN_NAME).HasMaxLength(255);

            Ignore(o => o.State);
        }
    }
}
