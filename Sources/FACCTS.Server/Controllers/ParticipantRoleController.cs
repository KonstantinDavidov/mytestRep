using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
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
    public class ParticipantRoleController : ApiControllerBase
    {
        // GET api/Designation
        public IEnumerable<ParticipantRole> Get()
        {
            return null;
        }

        // GET api/Designation/5
        public ParticipantRole Get(int id)
        {
            //var entity = DataManager.ParticipantRoleRepository.GetById(id);
            //if (entity == null)
            //{
            //    throw new HttpResponseException(
            //    Request.CreateResponse(
            //    HttpStatusCode.NotFound));
            //}
            //return entity;
            return ParticipantRole.Protected;
        }
    }
}
