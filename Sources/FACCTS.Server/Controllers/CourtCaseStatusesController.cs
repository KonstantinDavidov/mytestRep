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
    public class CourtCaseStatusesController : ApiController
    {
        [Import(typeof(IDataManager))]
        private IDataManager DataManager;

        // GET api/courtcasestatuses
        public IEnumerable<CourtCaseStatus> Get()
        {
            return DataManager.CourtCaseStatusesRepository.GetAll();
        }

        // GET api/courtcasestatuses/5
        public CourtCaseStatus Get(int id)
        {
            var entity = DataManager.CourtCaseStatusesRepository.GetById(id);
            {
                throw new HttpResponseException(
                Request.CreateResponse(
                HttpStatusCode.NotFound));
            }
            return entity;
        }
    }
}
