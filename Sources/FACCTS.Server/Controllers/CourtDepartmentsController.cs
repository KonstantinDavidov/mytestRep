using FACCTS.Server.Model.DataModel;
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
    [Authorize]
    public class CourtDepartmentsController : ApiControllerBase
    {
        public List<CourtDepartment> Get()
        {
            return DataManager.CourtDepartmentRepository.GetAll().ToList();
        }
    }
}
