using FACCTS.Server.Models;
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
    public class CourtCaseController : ApiControllerBase
    {
        public CourtCaseController() : base()
        {

        }

        public IEnumerable<CourtCaseHeading> GetHeadings()
        {
            return DataManager.CourtCaseRepository.GetAll()
                .Select(x => new { x.Id, x.CaseNumber, x.CaseStatus })
                .AsEnumerable()
                .Select(x => new CourtCaseHeading()
                {
                    Id = x.Id,
                    CaseNumber = x.CaseNumber,
                    CaseStatus = x.CaseStatus,
                });
        }
    }
}
