﻿using FACCTS.Server.Model.Calculations;
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
                throw new ArgumentNullException("criteria");
            }
            try
            {
                var query =
                    DataManager.CourtCaseRepository
                    .GetAll(
                    x => x.Hearings,
                    x => x.Hearings.Select(y => y.Courtroom),
                    x => x.Hearings.Select(y => y.Department),
                    x => x.Party1,
                    x => x.Party2,
                    x => x.Children
                    )
                    .Where(criteria.GetLINQCriteria());
                var data = query
                    .ToArray()
                    .Select(x => new DocketRecord()
                    {
                        CourtCaseId = x.Id,
                        CaseNumber = x.CaseNumber,
                        HearingDate = x.Hearings.OrderByDescending(y => y.HearingDate).First().HearingDate,
                        Courtroom = x.Hearings.OrderByDescending(y => y.HearingDate).First().Courtroom,
                        Department = x.Hearings.OrderByDescending(y => y.HearingDate).First().Department,
                        Session = x.Hearings.OrderByDescending(y => y.HearingDate).First().Session,
                        Party1Name = string.Format("{0} {1} {2}", x.Party1.FirstName, x.Party1.MiddleName, x.Party1.LastName),
                        Party2Name = string.Format("{0} {1} {2}", x.Party2.FirstName, x.Party2.MiddleName, x.Party2.LastName),
                        HasChildren = x.Children.Any(),
                        HearingIssue = x.Hearings.OrderByDescending(y => y.HearingDate).First().HearingIssues,
                    });
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception while getting thcourt docket: ", ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
