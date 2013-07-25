using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class CourtOrderConfiguration : EntityTypeConfiguration<CourtOrder>
    {
        public CourtOrderConfiguration()
        {
            ToTable(DbConsts.COURT_ORDERS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(o => o.Id);

            HasRequired(o => o.ParentHistoryNote).WithOptional(h => h.MasterOrder);
            HasMany(o => o.Attachments).WithOptional(a => a.ParentOrder).HasForeignKey(a => a.ParentOrderId);

            Property(o => o.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(o => o.OrderType).HasColumnName(DbConsts.COURT_ORDER_ORDER_TYPE_COLUMN_NAME);
            Property(o => o.XMLContent).HasColumnName(DbConsts.COURT_ORDER_XML_CONTENT_COLUMN_NAME).HasColumnType("xml");
            Property(o => o.IsSigned).HasColumnName(DbConsts.COURT_ORDER_IS_SIGNED_COLUMN_NAME);
            Property(o => o.ServerFileName).HasColumnName(DbConsts.COURT_ORDER_SERVER_FILE_NAME_COLUMN_NAME).HasMaxLength(255);
            Property(o => o.ParentOrderId).HasColumnName(DbConsts.COURT_ORDER_PARENT_ORDER_ID_COLUMN_NAME);

            Ignore(o => o.State);
        }
    }
}
