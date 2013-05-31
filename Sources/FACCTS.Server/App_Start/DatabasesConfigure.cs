using FACCTS.Server.Data;
using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FACCTS.Server.App_Start
{
    public class DatabasesConfigure
    {
        public static void ConfigureDB()
        {
            Database.SetInitializer<DatabaseContext>(new FacctsDatabaseInitializer());
            using (var facctsCtx = new DatabaseContext())
            {
                facctsCtx.Database.Initialize(force: false);
            }
        }
    }
}