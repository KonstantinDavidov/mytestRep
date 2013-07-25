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
    internal class RaceConfiguration : EntityTypeConfiguration<Race>
    {
        public RaceConfiguration()
        {
            ToTable(DbConsts.RACE_TABLE_NAME, DbConsts.SCHEMA_NAME);

            Property(r => r.Id).HasColumnName(DbConsts.ID_COLUMN_NAME).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(r => r.RaceName).HasColumnName(DbConsts.RACE_RACE_NAME_COLUMN_NAME).HasMaxLength(150);

            Ignore(r => r.State);
        }
    }
}
