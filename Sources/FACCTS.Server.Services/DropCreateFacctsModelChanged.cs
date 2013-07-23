﻿using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data
{
    public class DropCreateFacctsModelChanged : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            DatabaseHelper.SeedDatabase(context);
            base.Seed(context);
        }
    }
}
