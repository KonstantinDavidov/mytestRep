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
    internal class AppearanceConfiguration : EntityTypeConfiguration<Appearance>
    {
        public AppearanceConfiguration()
        {
            Map(m =>
            {
                m.ToTable(DbConsts.APPEARANCES_TABLE_NAME, DbConsts.SCHEMA_NAME);
                m.Requires(DbConsts.APPEARANCE_DISCRIMINATOR_COLUMN_NAME).HasValue((int)AppearanceType.Appearance);
            });

            HasKey(a => new { a.PersonId, a.HearingId });

            HasRequired(a => a.Person).WithMany(p=>p.Appearances).HasForeignKey(a => a.PersonId);
            HasRequired(a => a.Hearing).WithMany(h=>h.Appearances).HasForeignKey(a => a.HearingId);

            Property(a => a.PersonId).HasColumnName(DbConsts.APPEARANCE_PERSON_ID_COLUMN_NAME);
            Property(a => a.HearingId).HasColumnName(DbConsts.APPEARANCE_HEARING_ID_COLUMN_NAME);

            Ignore(a => a.State);
        }
    }
}
