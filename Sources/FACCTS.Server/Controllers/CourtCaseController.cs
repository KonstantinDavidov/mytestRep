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
        public CourtCaseController(ILog log) : base()
        {
            _logger = _logger;
        }

        private ILog _logger;

        public List<CourtCase> Get()
        {
            return DataManager.CourtCaseRepository.GetAll()
                .ToList();
        }

       
        public CourtCase Post([FromBody] CourtCaseCreationRequest courtCase)
        {
            //return CreateNewCourtCase(courtCase);
            return null;
            //return courtCase;
        }

        //private CourtCase CreateNewCourtCase(CourtCaseCreationRequest request)
        //{
        //    try
        //    {
        //        CourtCounty court = DataManager.CourtCountyRepository.GetById(request.CourtCountyId);
        //        CourtDepartment cd = DataManager.CourtDepartmentRepository.GetById(request.CourtDepartmentId);
        //        CourtCase cc = new CourtCase()
        //        {
        //            CaseNumber = request.CaseNumber,
                   
        //        };
        //        DataManager.CourtCaseRepository.Insert(cc);

        //        DataManager.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Fatal("Creating new court case failed", ex);
        //        throw;
        //    }
        //}
    }
}
