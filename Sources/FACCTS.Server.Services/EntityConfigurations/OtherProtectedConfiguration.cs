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
    internal class OtherProtectedConfiguration : EntityTypeConfiguration<OtherProtected>
    {
        public OtherProtectedConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.OtherProtected));

            Property(o => o.RelationshipToPlaintiff).HasColumnName(DbConsts.OTHER_PROTECTED_RELATIONSHIP_TO_PLAINTIFF_COLUMN_NAME);
            Property(o => o.IsHouseHold).HasColumnName(DbConsts.OTHER_PROTECTED_IS_HOUSE_HOLD_COLUMN_NAME);
        }
    }
}
