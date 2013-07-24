using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class AttorneyConfiguration: EntityTypeConfiguration<Attorney>
    {
        public AttorneyConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Attorney));

            Property(a => a.FirmName).HasColumnName(DbConsts.ATTORNEY_FIRM_NAME_COLUMN_NAME).HasMaxLength(100);
            Property(a => a.StateBarId).HasColumnName(DbConsts.ATTORNEY_STATE_BAR_ID_COLUMN_NAME).HasMaxLength(50);
        }
    }
}
