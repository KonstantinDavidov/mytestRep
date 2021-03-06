﻿using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.DataModel.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Thinktecture.IdentityModel.Constants;

namespace FACCTS.Server.Data
{
    [Export]
    public class FacctsDatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        public FacctsDatabaseInitializer() : base()
        {
            //Database.SetInitializer<IdentityServerConfigurationContext>(new ConfigurationDatabaseInitializer());
        }

        protected override void Seed(DatabaseContext context)
        {
            DatabaseHelper.SeedDatabase(context);
            base.Seed(context);
        }

    }
}
