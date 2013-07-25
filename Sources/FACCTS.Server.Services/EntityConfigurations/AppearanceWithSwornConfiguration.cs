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
    internal class AppearanceWithSwornConfiguration : EntityTypeConfiguration<AppearanceWithSworn>
    {
        public AppearanceWithSwornConfiguration()
        {
            Map(m => m.Requires(DbConsts.APPEARANCE_DISCRIMINATOR_COLUMN_NAME).HasValue((int)AppearanceType.AppearanceWithSworn));

            Property(a => a.Sworn).HasColumnName(DbConsts.APPEARANCE_SWORN_COLUMN_NAME);
        }
    }
}
