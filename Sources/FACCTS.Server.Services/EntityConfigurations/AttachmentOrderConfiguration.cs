using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class AttachmentOrderConfiguration : EntityTypeConfiguration<AttachmentOrder>
    {
        public AttachmentOrderConfiguration()
        {
            ToTable(DbConsts.ATTACHMENT_ORDERS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(a => a.Id);

            Property(a => a.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(a => a.OrderType).HasColumnName(DbConsts.ATTACHMENT_ORDERS_ORDER_TYPE_COLUMN_NAME);
            Property(a => a.XmlContent).HasColumnType(DbConsts.ATTACHMENT_ORDERS_XML_CONTENT_COLUMN_NAME).HasColumnType("xml");
            Property(a => a.ServerFileName).HasColumnName(DbConsts.ATTACHMENT_ORDERS_SERVER_FILE_NAME_COLUMN_NAME).HasMaxLength(255);

            Ignore(a => a.State);
        }
    }
}
