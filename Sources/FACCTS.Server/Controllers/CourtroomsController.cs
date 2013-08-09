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
        public List<CourtRoom> Get(int courtCountyId)
        {
            var courtCounty = DataManager.CourtCountyRepository.GetAll("CourtLocations").SingleOrDefault(x => x.Id == courtCountyId);
            if (courtCounty == null)
            {
                 throw new HttpResponseException(
                Request.CreateResponse(
                HttpStatusCode.NotFound));
            }
            return courtCounty.CourtLocations.SelectMany(x => DataManager.CourtroomRepository.GetAll("CourtLocation").Where(y => y.CourtLocation.Id == x.Id)).ToList();
        }

    }
}
