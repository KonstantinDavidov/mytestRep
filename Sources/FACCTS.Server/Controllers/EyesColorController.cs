using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services;
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
    public class EyesColorController : ApiController
    {
        [Import(typeof(IDataManager))]
        private IDataManager DataManager;

        // GET api/eyescolor
        public IEnumerable<EyesColor> Get()
        {
            return DataManager.EyesColorRepository.Get();
        }

        // GET api/eyescolor/5
        public EyesColor Get(int id)
        {
            var entity = DataManager.EyesColorRepository.Get(x => x.Id == id).FirstOrDefault();
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
