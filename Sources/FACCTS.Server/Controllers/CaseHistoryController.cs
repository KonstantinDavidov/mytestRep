using FACCTS.Server.Model;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.DataModel;
using log4net;
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
    public class CaseHistoryController : ApiControllerBase
    {
        private ILog _logger;

        [ImportingConstructor]
        public CaseHistoryController(ILog logger) : base()
        {
            _logger = logger;
        }

        public HttpResponseMessage Get(long courtCaseId)
        {
            _logger.Info(string.Format("Calling CaseHistoryController.Get (courtCaseId = {0})", courtCaseId));
            try
            {
                var data = DataManager
                    .CaseHistoryRepository
                    .GetAll(
                    x => x.Hearing,
                    x => x.Hearing.CourtOrders,
                    x => x.CourtClerk
                    )
                    .Where(x => x.CourtCaseId == courtCaseId)
                    .OrderByDescending(x => x.Date)
                    .Select(x =>
                    new
                    {
                        CourtCaseId = x.CourtCaseId,
                        CaseNumber = (string)null,
                        CasehistoryEvent = x.CaseHistoryEvent,
                        Date = x.Date,
                        Order = x.Hearing.CourtOrders.Select(y => y.OrderType),
                        Party1Name = (string)null,
                        Party2Name = (string)null,
                        CourtClerkName = x.CourtClerk.FirstName + " " + x.CourtClerk.MiddleName + " " + x.CourtClerk.LastName,
                        CCPOR_ID = (string)null,
                    }
                    )
                    .ToArray()
                    .Select(x => new CourtCaseHeading()
                    {
                        CourtCaseId = x.CourtCaseId,
                        CaseNumber = x.CaseNumber,
                        CaseStatus = CaseHistoryEventToCaseStatusConverter.Convert(x.CasehistoryEvent),
                        Date = x.Date,
                        Order = string.Concat(x.Order.Select(y => y.ToString()+"|")).TrimEnd('|'),
                        Party1Name = x.Party1Name,
                        Party2Name = x.Party2Name,
                        CourtClerkName = x.CourtClerkName,
                        CCPOR_ID = x.CCPOR_ID,
                    }
                    );
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                _logger.Error("CaseHistoryController.Get: an exception thrown while querying the database", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
