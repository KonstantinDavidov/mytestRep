using FACCTS.Server.Code;
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

        public List<CourtCase> Get()
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
                x => x.Interpreters,
                x => x.Witnesses,
                x => x.Children,
                x => x.OtherProtected,
                x => x.AttorneyForChild,
                x => x.ThirdPartyData,
                x => x.ThirdPartyData.Attorney
                )
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
                        CaseHistoryEvent = Model.Enums.CaseHistoryEvent.New
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
