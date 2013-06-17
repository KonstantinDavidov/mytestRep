using FACCTS.Server.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ApiControllerBase : ApiController
    {
        [Import(typeof(IDataManager))]
        protected IDataManager DataManager;

        protected override void Dispose(bool disposing)
        {
            DataManager.Dispose();
            base.Dispose(disposing);
        }
        
    }
}
