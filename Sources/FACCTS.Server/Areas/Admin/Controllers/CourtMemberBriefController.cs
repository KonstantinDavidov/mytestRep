using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FACCTS.Server.Controllers;

namespace FACCTS.Server.Areas.Admin.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CourtMemberBriefController : ApiControllerBase
    {
        // GET api/courtmemberbrief
        public IEnumerable<CourtMemberBrief> Get()
        {
            return this.DataManager.CourtMemberRepository.GetBriefs();
        }
    }
}
