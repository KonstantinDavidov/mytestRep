using FACCTS.Server.BusinessLogic;
using FACCTS.Server.BusinessLogic.BusinessOperations;
using FACCTS.Server.Code;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Filters;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Models;
using log4net;
using Microsoft.Practices.ServiceLocation;
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
        public CourtCaseController(
            ILog log

            )
            : base()
        {
            _logger = log;
        }

        private ILog _logger;

        public CourtCase Get(long courtCaseId)
        {
            return DataManager.CourtCaseRepository
                .GetAll(
                x => x.Party1,
                x => x.Party1.HairColor,
                x => x.Party1.EyesColor,
                x => x.Party1.Race,
                x => x.Party1.Attorney,
                x => x.Party2,
                x => x.Party2.HairColor,
                x => x.Party2.EyesColor,
                x => x.Party2.Race,
                x => x.Party2.Attorney,
                x => x.CaseHistory,
                x => x.CaseNotes,
                x => x.CaseNotes.Select(y => y.Author),
                x => x.Interpreters,
                x => x.Witnesses,
                x => x.Children,
                x => x.OtherProtected,
                x => x.AttorneyForChild,
                x => x.ThirdPartyData,
                x => x.ThirdPartyData.Attorney
                )
                .Where(x => x.Id == courtCaseId)
                .FirstOrDefault();
        }

        public HttpResponseMessage Get([FromUri]CourtCaseSearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
            {
                _logger.Error("CourtCaseController.Get: searchCriteria is null");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException("searchCriteria"));
            }
            try
            {
                using (SearchCourtCasesStrategy s = new SearchCourtCasesStrategy(searchCriteria))
                {
                    s.Execute();
                    return Request.CreateResponse(HttpStatusCode.OK, s.Result);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("CourtCaseController.Get: an exception thrown while querying the database: ", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }


        public HttpResponseMessage Post([FromBody] CourtCaseCreationRequest courtCase)
        {
            return CreateNewCourtCase(courtCase);
        }

        public HttpResponseMessage Put([FromBody] CourtCase courtCase)
        {
            HttpResponseMessage msg = null;
            try
            {
                using (SaveCourtCaseStrategy strategy = new SaveCourtCaseStrategy(courtCase))
                {
                    strategy.Execute();
                }
                msg = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return msg;
        }

        private HttpResponseMessage CreateNewCourtCase(CourtCaseCreationRequest request)
        {
            try
            {
                using (CreateNewCourtCaseStrategy strategy = new CreateNewCourtCaseStrategy(request.CaseNumber, request.CourtClerkId))
                {
                    strategy.Execute();
                }
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                _logger.Fatal("Creating new court case failed", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }
        
    }
}
