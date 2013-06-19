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
    public class CourtroomsController : ApiControllerBase
    {
       

        // GET api/courtrooms/5
        public List<Courtroom> Get(int courtCountyId)
        {
            return DataManager.CourtCountyRepository.GetById(courtCountyId).CourtLocations.SelectMany(x => x.Courtrooms).ToList();
        }

    }
}
