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
            testModel.ConductSection = new CH130ConductChoice();
            testModel.ConductSection.IsEnabled = true;
            testModel.ConductSection.NoAbuse = true;
            testModel.ConductSection.NoContact = false;
            testModel.ConductSection.Other = true;
            testModel.ConductSection.OtherDescription = "Some Description";
            
            //string curDir = AppDomain.CurrentDomain.BaseDirectory;
            IDataManager dm = new DataManager( new RepositoryProvider(new RepositoryFactories()));

            CourtCase cc = dm.CourtCaseRepository.GetAll().FirstOrDefault();

            testModel.CaseId = cc.Id;
                      
            var res = OrderGenerator.GenerateOrder(testModel, dm, @"..\..\Resources\ch130.pdf",  @"..\..\Resources\Mappers\ch130.xml");
            FileStream file = new FileStream(@"E:\test1.pdf", FileMode.Create, System.IO.FileAccess.Write);
            file.Write(res, 0, res.Length);
            file.Close();
           
        }
    }
}
