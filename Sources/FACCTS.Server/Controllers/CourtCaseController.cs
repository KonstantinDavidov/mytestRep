using FACCTS.Server.DataContracts;
using FACCTS.Server.Filters;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thinktecture.IdentityModel.Authorization.WebApi;
using Thinktecture.IdentityServer;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class CourtCaseController : ApiControllerBase
    {
        [ImportingConstructor]
        public CourtCaseController(ILog log)
            : base()
        {
            _logger = log;
        }

        private ILog _logger;

        public List<CourtCase> Get()
        {
            return DataManager.CourtCaseRepository.GetAll()
                .ToList();
        }


        public CourtCase Post([FromBody] CourtCaseCreationRequest courtCase)
        {
            return CreateNewCourtCase(courtCase);
            //return null;
            //return courtCase;
        }

        public HttpResponseMessage Put([FromBody] CourtCase courtCase)
        {
            HttpResponseMessage msg = null;
            msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Court Case not Found");

            return msg;
        }

        private CourtCase CreateNewCourtCase(CourtCaseCreationRequest request)
        {
            CourtCase courtCase;
            try
            {
                courtCase = new CourtCase()
                {
                    CaseNumber = request.CaseNumber,

                };
                courtCase.CaseRecord = new CaseRecord();
                courtCase.CaseRecord.CaseHistory = new List<CaseHistory>()
                {
                    new CaseHistory()
                    {
                        Date = DateTime.Now,
                        CaseHistoryEvent = Model.Enums.CaseHistoryEvent.New,
                        CaseRecord = courtCase.CaseRecord,
                    }
                };
                DataManager.CourtCaseRepository.Insert(courtCase);

                DataManager.Commit();

            }
            catch (Exception ex)
            {
                _logger.Fatal("Creating new court case failed", ex);
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
            try
            {
                return DataManager.CourtCaseRepository.GetById(courtCase.Id);
            }
            catch (Exception ex)
            {
                _logger.Fatal("Inserted record bot found", ex);
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            
        }
    }
}
