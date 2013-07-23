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
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RaceController : ApiControllerBase
    {
        // GET api/Designation
        public IEnumerable<Race> Get()
        {
            return DataManager.RaceRepository.GetAll();
        }

        // GET api/Designation/5
        public Race Get(int id)
        {
            var entity = DataManager.RaceRepository.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(
                Request.CreateResponse(
                HttpStatusCode.NotFound));
            }
            return entity;
        }
    }
}
