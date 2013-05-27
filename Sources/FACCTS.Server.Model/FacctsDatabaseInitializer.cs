using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model
{
    public class FacctsDatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //TODO: implement default filling of the database tables
            base.Seed(context);
        }
    }
}
