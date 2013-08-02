using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FACCTS.Server.Controllers;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.ServiceLocation;
using log4net;
using FACCTS.Server.Code;
using FACCTS.Server.Models;
using System.Net.Http;
using System.ComponentModel.Composition;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Hosting;

namespace FACCTS.Server.Tests.Controllers
{
    [TestClass]
    public class CourtCaseControllerTest : ControllerTestBase
    {

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Configuration = new HttpConfiguration();
            GetRequest = new HttpRequestMessage(HttpMethod.Get, "https://localhost/FACCTS.Server/api/CourtCase");
            var route = Configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            RouteData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "CourtCase" } });
        }

        protected static HttpConfiguration Configuration { get; set; }
        protected static HttpRequestMessage GetRequest { get; set; }
        protected static HttpRouteData RouteData { get; set; }

        [TestMethod]
        public void TestCourtCaseSearchCriteria()
        {
            using (CourtCaseController courtCaseController = new CourtCaseController(
                ServiceLocator.Current.GetInstance<ILog>(),
                ServiceLocator.Current.GetInstance<DataSaver>()
                ))
            {
                courtCaseController.ControllerContext = new HttpControllerContext(Configuration, RouteData, GetRequest);
                courtCaseController.Request = GetRequest;
                courtCaseController.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = Configuration;
                Contailer.SatisfyImportsOnce(courtCaseController);
                CourtCaseSearchCriteria ss = new CourtCaseSearchCriteria();
                ss.Party1FirstName = "Catty";
                ss.Party1LastName = "Smith";
                ss.CaseStatus = Model.Enums.CaseStatus.Active;
                HttpResponseMessage response =  courtCaseController.Get(ss);
                response.EnsureSuccessStatusCode();

            }
        }
    }
}
