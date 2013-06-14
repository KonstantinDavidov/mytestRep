using FACCTS.Server.Filters;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thinktecture.IdentityModel.Authorization.WebApi;
using Thinktecture.IdentityServer;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class CourtCaseController : ApiControllerBase
    {
        public CourtCaseController() : base()
        {

        }

        public List<CourtCase> Get()
        {
            return DataManager.CourtCaseRepository.GetAll()
                .ToList();
        }

       
        public CourtCase Post([FromBody] CourtCaseCreationRequest courtCase)
        {
            return CreateNewCourtCase(courtCase);
            //return courtCase;
        }

        private static CourtCase CreateNewCourtCase(CourtCaseCreationRequest request)
        {
            return null;
        }
    }
}
