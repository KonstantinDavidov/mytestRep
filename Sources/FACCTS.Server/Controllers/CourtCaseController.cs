using FACCTS.Server.Code;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Filters;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Calculations;
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
        private DataSaver _dataSaver;

        [ImportingConstructor]
        public CourtCaseController(
            ILog log
            , DataSaver dataSaver
            )
            : base()
        {
            _logger = log;
            _dataSaver = dataSaver;
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
                var data = DataManager.CourtCaseRepository
                .GetAll(
                x => x.Party1,
                x => x.Party2,
                x => x.CaseHistory,
                x => x.CourtClerk
                )
                .Where(searchCriteria.GetLINQCriteria())
                .Select(x =>
                    new {
                        CourtCaseId = x.Id,
                        CaseNumber = x.CaseNumber,
                        CasehistoryEvent = x.CaseHistory.OrderByDescending(y => y.Date).Select(y => y.CaseHistoryEvent).FirstOrDefault(),
                        Date = (DateTime?)null,
                        Order = (string)null,
                        Party1Name = x.Party1.FirstName + " " +x.Party1.MiddleName + " " + x.Party1.LastName,
                        Party2Name = x.Party2.FirstName + " " + x.Party2.MiddleName + " " + x.Party2.LastName,
                        CourtClerkName = x.CourtClerk.FirstName + " " + x.CourtClerk.MiddleName + " " + x.CourtClerk.LastName,
                        CCPOR_ID = x.CCPORId,
                    }
                    )
                    .ToArray()
                .Select(
                x => new CourtCaseHeading()
                {
                    CourtCaseId = x.CourtCaseId,
                    CaseNumber = x.CaseNumber,
                    CaseStatus = CaseHistoryEventToCaseStatusConverter.Convert(x.CasehistoryEvent),
                    Date = null,
                    Order = null,
                    Party1Name = x.Party1Name,
                    Party2Name = x.Party2Name,
                    CourtClerkName = x.CourtClerkName,
                    CCPOR_ID = x.CCPOR_ID,
                }
                )
                .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                _logger.Error("CourtCaseController.Get: an exception thrown while querying the database: ", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
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
            try
            {
                _dataSaver.SaveData(courtCase);
                msg = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            //msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Court Case not Found");

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
                courtCase.CaseHistory = new List<CaseHistory>()
                {
                    new CaseHistory()
                    {
                        Date = DateTime.Now,
                        CaseHistoryEvent = Model.Enums.CaseHistoryEvent.File
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataSaver.Dispose();
                _dataSaver = null;
            }
            base.Dispose(disposing);
        }
    }
}
