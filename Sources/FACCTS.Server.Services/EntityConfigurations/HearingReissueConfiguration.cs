using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    public class HearingReissueConfiguration : EntityTypeConfiguration<HearingReissue>
    {
        public HearingReissueConfiguration()
            : base()
        {
            ToTable(DbConsts.HEARING_REISSUE_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(h => h.Id);

            Property(h => h.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(h => h.ReissueServiceSpecification).HasColumnName(DbConsts.HEARING_REISSUE_SERICE_SPECIFICATION);
            Property(h => h.DaysCount).HasColumnName(DbConsts.HEARING_REISSUE_DAYS_COUNT);

            Ignore(h => h.State);
        }
    }
}
