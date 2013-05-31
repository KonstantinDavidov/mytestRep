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
    public class ApiControllerBase : ApiController
    {
        [Import(typeof(IDataManager))]
        protected IDataManager DataManager;
    }
}
