using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FACCTS.Server.Data;
using System.ComponentModel.Composition;
using FACCTS.Server.DataContracts;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HairColorController : ApiControllerBase
    {
        // GET api/haircolor
        public IEnumerable<HairColor> Get()
        {
            var data = DataManager.HairColorRepository.GetAll();
            return data;
        }

        // GET api/haircolor/5
        public HairColor Get(int id)
        {
            var hc = DataManager.HairColorRepository.GetById(id);
            if (hc == null)
            {
                throw new HttpResponseException(
                Request.CreateResponse(
                HttpStatusCode.NotFound));
            }
            return hc;
        }
    }
}
