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
    internal class InterpreterConfiguration : EntityTypeConfiguration<Interpreter>
    {
        public InterpreterConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.Interpreter));

            Property(i => i.Language).HasColumnName(DbConsts.INTERPRETER_LANGUAGE_COLUMN_NAME).HasMaxLength(150);
            Property(i => i.InterpreterFor).HasColumnName(DbConsts.INTERPRETER_FOR_COLUMN_NAME);
        }
    }
}
