using FACCTS.Server.Data;
using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateFacctsModelChanged());
            using (var facctsCtx = new DatabaseContext())
            {
                facctsCtx.Database.Initialize(force: false);
            }
        }
    }
}
