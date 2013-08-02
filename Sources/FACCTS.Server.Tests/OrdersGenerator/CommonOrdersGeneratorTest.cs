using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FACCTS.Server.Models;
using FACCTS.Server.Reporting;
using FACCTS.Server.Model.OrderModels;
using System.IO;
using System.Reflection;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Data;
using FACCTS.Server.Data.Repositiries.Helpers;
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
            //CH130 testModel = new CH130();
            //testModel.ConductSection = new CH130ConductChoice();
            //testModel.ConductSection.IsEnabled = true;
            //testModel.ConductSection.IsNoAbuse = true;
            //testModel.ConductSection.IsNoContact = true;
            //testModel.ConductSection.IsDontTryToLocate = true;
            //testModel.ConductSection.IsOtherAttached = true;
            //testModel.ConductSection.IsInvolveOther = true;
            //testModel.ConductSection.IsInvolveOtherProtected = true;
            //testModel.ConductSection.OtherDescription = "Some Description";

            //testModel.StayAwayOrdersSection = new CH130StayAwayOrders();
            //testModel.StayAwayOrdersSection.IsEnabled = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromChildCare = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromChildSchool = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromHome = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromWork = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromPerson = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromVehicle = true;
            //testModel.StayAwayOrdersSection.IsAttachOther = true;
            //testModel.StayAwayOrdersSection.IsStayAwayFromOther = true;
            //testModel.StayAwayOrdersSection.OtherDescription = "Some description";
            //testModel.StayAwayOrdersSection.IsStayAwayFromOtherProtected = true;
            //testModel.StayAwayOrdersSection.StayAwayDistance = 20;

            //testModel.IsNoGuns = true;

            //testModel.IsExpire = true;
            //testModel.OrdersEndDate = new Nullable<DateTime>(DateTime.Now.Date.Add(new TimeSpan(2, 5, 15)));
            //testModel.OrdersEndTime = new Nullable<DateTime>(DateTime.Now.Date.Add(new TimeSpan(20, 5, 15)));

            //testModel.CAPROSEntrySection = new CAPROSEntry();
            //testModel.CAPROSEntrySection.CARPOSEntryType = CARPOSEntryType.ByProtected;
            //testModel.CAPROSEntrySection.LawEnforcementAgencies = new List<DataItem>();
            //testModel.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem{ Name="Agency1", Description="Address1"});
            //testModel.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem{Name = "Agency2", Description="Address2"});
            //testModel.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency3", Description = "Address3" });
            //testModel.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency4", Description = "Address4" });
            //testModel.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency5", Description = "Address5" });

            //testModel.NoServiceFeeSection = new NoServiceFee();
            //testModel.NoServiceFeeSection.IsOrdered = true;
            //testModel.NoServiceFeeSection.IsBasedOnViolence = true;
            //testModel.NoServiceFeeSection.IsFeeWaiver = true;

            //testModel.LawersFeeAndCourtCostsSection.IsEnabled = true;
            //testModel.LawersFeeAndCourtCostsSection.IsCourtCosts = true;
            //testModel.LawersFeeAndCourtCostsSection.IsLawyerFee = true;
            //testModel.LawersFeeAndCourtCostsSection.Payer = ParticipantRole.PPSC;
            //testModel.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem{ Name="Agency1", Description="Cost1"});
            //testModel.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem{Name = "Agency2", Description="Cost2"});
            //testModel.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency3", Description = "Cost3" });
            //testModel.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency4", Description = "Cost4" });
            //testModel.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency5", Description = "Cost5" });

            //testModel.IsOtherOrdersAttached = true;
            //testModel.OtherOrderDetail = "Some Details ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt";

            //testModel.IsPOSGeneral = true;
            
            //IDataManager dm = new DataManager( new RepositoryProvider(new RepositoryFactories()));

            //CaseHistory cc = dm.CaseHistoryRepository.GetAll().FirstOrDefault();

            //testModel.CaseHistoryId = cc.Id;
                      
            //var res = OrderGenerator.GenerateOrder(testModel, dm, @"..\..\Resources\ch130.pdf",  @"..\..\Resources\Mappers\ch130.xml");
            //FileStream file = new FileStream(@"E:\test1.pdf", FileMode.Create, System.IO.FileAccess.Write);
            //file.Write(res, 0, res.Length);
            //file.Close();
           
        }
    }
}
