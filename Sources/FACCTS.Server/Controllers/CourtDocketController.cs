using FACCTS.Server.Code;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class CourtDocketController : ApiControllerBase
    {
        private ILog _logger;
        [ImportingConstructor]
        public CourtDocketController(ILog logger)
            : base()
        {
            _logger = logger;
        }

        public HttpResponseMessage Get([FromUri] CourtDocketSearchCriteria criteria)
        {
            _logger.InfoFormat("Running {0}.{1}", this.GetType().Name, "Get");
            if (criteria == null)
            {
                _logger.FatalFormat("{0}.{1} - search criteria is null!", this.GetType().Name, "Get");
                Exception ex = new ArgumentNullException("criteria");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex); 
            }
            try
            {
                var nextDay = criteria.Date.Date.AddDays(1);
                var query =
                    DataManager.HearingRepository
                    .GetAll(
                    x => x.CourtCase
                        , x => x.Courtroom
                        , x => x.Department
                        , x => x.CourtCase.Party1
                        , x => x.CourtCase.Party2
                        , x => x.CourtCase.Children
                    )
                    .Where(x => x.HearingDate >= criteria.Date.Date && x.HearingDate < nextDay)
                    .Where(x => 
                    (!criteria.Session.HasValue || x.Session == criteria.Session.Value) &&
                    (!criteria.CourtRoomId.HasValue || x.CourtroomId == criteria.CourtRoomId)
                    )
                    .Select(x =>
                    new { 
                        Id = x.CourtCaseId,
                        CaseNumber = x.CourtCase.CaseNumber,
                        HearingDate = x.HearingDate,
                        Courtroom = x.Courtroom,
                        Department = x.Department,
                        Session = x.Session,
                        Party1 = x.CourtCase.Party1,
                        Party2 = x.CourtCase.Party2,
                        HasChildren = x.CourtCase.Children.Any(),
                        HearingIssue = x.HearingIssues,
                    }
                    )
                    .ToArray();
                var data = query
                    .Select(x => new DocketRecord()
                    {
                        CourtCaseId = x.Id,
                        CaseNumber = x.CaseNumber,
                        HearingDate = x.HearingDate,
                        Courtroom = x.Courtroom,
                        Department = x.Department,
                        Session = x.Session,
                        Party1Name = string.Format("{0} {1} {2}", x.Party1.FirstName, x.Party1.MiddleName, x.Party1.LastName),
                        Party2Name = string.Format("{0} {1} {2}", x.Party2.FirstName, x.Party2.MiddleName, x.Party2.LastName),
                        HasChildren = x.HasChildren,
                        HearingIssue = x.HearingIssue,
                    })
                    .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception while getting thcourt docket: ", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Put([FromBody] IEnumerable<DocketRecord> docketRecords)
        {
            _logger.InfoFormat("{0}.{1} : trying to update the court docket...", this.GetType().Name, "Put");
            try
            {
                foreach (var docket in docketRecords)
                {
                    var courtCase = DataManager.CourtCaseRepository
                            .GetAll(
                            x => x.CaseHistory,
                            x => x.Hearings
                            ).FirstOrDefault(x => x.Id == docket.CourtCaseId);
                    if (courtCase == null)
                    {
                        string message = string.Format("Court case with the id = {0} was not found!", docket.CourtCaseId);
                        _logger.Error(message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                    var hearing = new Hearing()
                            {
                                HearingDate = docket.HearingDate,
                                HearingIssues = docket.HearingIssue,
                                Courtroom = DataManager.CourtroomRepository.GetById(docket.Courtroom.Id),
                                Department = DataManager.CourtDepartmentRepository.GetById(docket.Department.Id),
                                Session = docket.Session,
                                State = ObjectState.Added,
                            };
                    courtCase.Hearings.Add(hearing);
                    courtCase.CaseHistory.Add(
                        new CaseHistory()
                        {
                            CaseHistoryEvent = Model.Enums.CaseHistoryEvent.Hearing,
                            Hearing = hearing,
                            Date = DateTime.Now,
                            CourtClerk = docket.CourtClerkId.HasValue ? DataManager.UserRepository.GetById(docket.CourtClerkId.Value) : null,
                            State = ObjectState.Added,
                        }
                        );
                    courtCase.LastAction = docket.Action.GetValueOrDefault(CourtAction.Docketed);
                    courtCase.State = ObjectState.Modified;
                    DataManager.CourtCaseRepository.ModifyByState(courtCase);

                }

                DataManager.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception while updating the court docket: ", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
