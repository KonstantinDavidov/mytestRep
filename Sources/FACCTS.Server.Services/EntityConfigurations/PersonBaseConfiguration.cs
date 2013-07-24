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
    internal class PersonBaseConfiguration : EntityTypeConfiguration<PersonBase>
    {
        public PersonBaseConfiguration()
        {
            Map(m =>
            {
                m.ToTable(DbConsts.PERSONS_TABLE_NAME, DbConsts.SCHEMA_NAME);
                m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.None);
            })
            .Map<Child>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Child))
            .Map<Attorney>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Attorney))
            .Map<CourtParty>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.CourtParty))
            .Map<OtherProtected>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.OtherProtected))
            .Map<Witness>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Witness))
            .Map<Interpreter>(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Interpreter));

            HasKey(p => p.Id);

            Property(p => p.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(p => p.FirstName).HasColumnName(DbConsts.PERSON_FIRST_NAME_COLUMN_NAME);
            Property(p => p.LastName).HasColumnName(DbConsts.PERSON_LAST_NAME_COLUMN_NAME);
            Property(p => p.EntityType).HasColumnName(DbConsts.PERSON_ENTITY_TYPE_COLUMN_NAME);
            Property(p => p.Sex).HasColumnName(DbConsts.PERSON_SEX_COLUMN_NAME);
            Property(p => p.DateOfBirth).HasColumnName(DbConsts.PERSON_DATE_OF_BIRTH_COLUMN_NAME);
            Property(p => p.Contact).HasColumnName(DbConsts.PERSON_CONTACT_COLUMN_NAME);
            Property(p => p.Age).HasColumnName(DbConsts.PERSON_AGE_COLUMN_NAME);
            Property(p => p.Email).HasColumnName(DbConsts.PERSON_EMAIL_COLUMN_NAME).HasMaxLength(50);

            Ignore(p => p.State);
        }
    }
}
