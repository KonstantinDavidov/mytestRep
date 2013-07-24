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
    public class DesignationController : ApiControllerBase
    {
        /*// GET api/Designation
        public IEnumerable<Designation> Get()
        {
            return DataManager.DesignationRepository.GetAll();
        }

        // GET api/Designation/5
        public Designation Get(int id)
        {
            var entity = DataManager.DesignationRepository.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(
                Request.CreateResponse(
                HttpStatusCode.NotFound));
            }
            return entity;
        }*/
    }
}
