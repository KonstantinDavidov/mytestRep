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
    internal class WitnessConfiguration : EntityTypeConfiguration<Witness>
    {
        public WitnessConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Witness));

            Property(w => w.WitnessFor).HasColumnName(DbConsts.PERSON_COURT_PARTY_FOR_COLUMN_NAME);
        }
    }
}
