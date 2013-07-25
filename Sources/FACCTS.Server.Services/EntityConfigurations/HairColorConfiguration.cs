using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class HairColorConfiguration : EntityTypeConfiguration<HairColor>
    {
        public HairColorConfiguration()
        {
            ToTable(DbConsts.HAIR_COLORS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName(DbConsts.ID_COLUMN_NAME).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Color).HasColumnName(DbConsts.HAIR_COLOR_COLOR_COLUMN_NAME).HasMaxLength(150);

            Ignore(c => c.State);
        }
    }
}
