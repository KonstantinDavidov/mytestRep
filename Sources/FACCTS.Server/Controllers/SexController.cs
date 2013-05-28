using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services;
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
    public class SexController : ApiController
    {
        [Import(typeof(IDataManager))]
        private IDataManager DataManager;
        // GET api/sex
        public IEnumerable<Sex> Get()
        {
            return DataManager.SexRepository.GetAll();
        }

        // GET api/sex/5
        public Sex Get(int id)
        {
            var entity = DataManager.SexRepository.GetAll().FirstOrDefault(x => x.Id == id);
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
