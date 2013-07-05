using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FACCTS.Server.Models;
using FACCTS.Server.Reporting;
using FACCTS.Server.Model.OrderModels;
using System.IO;
using System.Reflection;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Data;
using FACCTS.Server.Data.Repositiries.Helpers;
using FACCTS.Server.Model.Reporting.Entities;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.DataModel;
using System.Linq;

namespace FACCTS.Server.Tests.OrdersGenerator
{
    [TestClass]
    public class CommonOrdersGeneratorTest
    {
        [TestMethod]
        public void TestReflection()
        {
            CH130 testModel = new CH130();
            
            //string curDir = AppDomain.CurrentDomain.BaseDirectory;
            IDataManager dm = new DataManager( new RepositoryProvider(new RepositoryFactories()));

            CourtCase cc = dm.CourtCaseRepository.GetAll().FirstOrDefault();

            testModel.CaseInfo = new CaseInfo();
            testModel.CaseInfo.CaseId = cc.Id;
            testModel.CaseInfo.CaseNumber = "22 - 2222";
            testModel.CaseInfo.CasesCompleteHead = 5;
            testModel.CaseInfo.CasesOnDocket = 3;
            testModel.CaseInfo.IsSealed = false;
            testModel.CaseInfo.IsTempJudge = true;
            testModel.CaseInfo.TempJudgeName = "John Smith";

            testModel.Party1 = new Model.Reporting.Entities.Party();
            testModel.Party1.IsPresent = true;
            testModel.Party1.IsSworn = false;
            testModel.Party1.Name = "Test Protected";
            testModel.Party1.Parent = "Mother";
            testModel.Party1.Designation = new Model.DataModel.Designation() { DesignationName = "Des1", Id = 23 };
            testModel.Party1.HasAttorney = true;
            testModel.Party1.ParticipantRole = FACCTS.Server.Model.Enums.ParticipantRole.Protected;

            var res = OrderGenerator.GenerateOrder(testModel, dm, @"..\..\Resources\ch130.pdf",  @"..\..\Resources\Mappers\ch130.xml");
            FileStream file = new FileStream(@"C:\test.pdf", FileMode.Create, System.IO.FileAccess.Write);
            file.Write(res, 0, res.Length);
            file.Close();
           
        }
    }
}
