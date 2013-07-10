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
            testModel.ConductSection.NoContact = true;
            testModel.ConductSection.DontTryToLocate = true;
            testModel.ConductSection.IsOtherAttached = true;
            testModel.ConductSection.Other = true;
            testModel.ConductSection.OtherDescription = "Some Description";

            testModel.StayAwayOrdersSection = new CH130StayAwayOrders();
            testModel.StayAwayOrdersSection.IsEnabled = true;
            testModel.StayAwayOrdersSection.ChildCare = true;
            testModel.StayAwayOrdersSection.ChildSchool = true;
            testModel.StayAwayOrdersSection.Home = true;
            testModel.StayAwayOrdersSection.Work = true;
            testModel.StayAwayOrdersSection.Person = true;
            testModel.StayAwayOrdersSection.Vehicle = true;
            testModel.StayAwayOrdersSection.IsAttach = true;
            testModel.StayAwayOrdersSection.Other = true;
            testModel.StayAwayOrdersSection.OtherDescription = "Some description";
            testModel.StayAwayOrdersSection.OtherProtected = true;
            //string curDir = AppDomain.CurrentDomain.BaseDirectory;
            IDataManager dm = new DataManager( new RepositoryProvider(new RepositoryFactories()));

            CaseHistory cc = dm.CaseHistoryRepository.GetAll().FirstOrDefault();

            testModel.CaseHistoryId = cc.Id;
                      
            var res = OrderGenerator.GenerateOrder(testModel, dm, @"..\..\Resources\ch130.pdf",  @"..\..\Resources\Mappers\ch130.xml");
            FileStream file = new FileStream(@"E:\test1.pdf", FileMode.Create, System.IO.FileAccess.Write);
            file.Write(res, 0, res.Length);
            file.Close();
           
        }
    }
}
