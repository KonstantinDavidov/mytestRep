using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FACCTS.Server.Services;
using System.ComponentModel.Composition;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HairColorController : ApiController
    {
        [Import(typeof(IDataManager))]
        private IDataManager DataManager;

        // GET api/haircolor
        public IEnumerable<HairColor> Get()
        {
            //var data = DataManager.HairColorRepository.Get();
            IEnumerable<HairColor> data;
            using (DatabaseContext ctx = new DatabaseContext())
            {
                data = from hc in ctx.HairColor
                       select hc;
            }
            return data;
        }

        // GET api/haircolor/5
        public HairColor Get(int id)
        {
            var hc = DataManager.HairColorRepository.Get(h => h.Id == id).FirstOrDefault();
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
