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

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class EyesColorController : ApiControllerBase
    {
        // GET api/eyescolor
        public IEnumerable<EyesColor> Get()
        {
            return DataManager.EyesColorRepository.GetAll();
        }

        // GET api/eyescolor/5
        public EyesColor Get(int id)
        {
            var entity = DataManager.EyesColorRepository.GetById(id);
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
