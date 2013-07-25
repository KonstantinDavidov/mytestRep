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
    internal class ChildConfiguration : EntityTypeConfiguration<Child>
    {
        public ChildConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Child));

            Property(c => c.RelationshipToProtected).HasColumnName(DbConsts.CHILD_RELATIONSHIP_TO_PROTECTED_COLUMN_NAME);            
        }
    }
}
