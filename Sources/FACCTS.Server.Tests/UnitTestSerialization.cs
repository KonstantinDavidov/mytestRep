using FACCTS.Server.Data;
using FACCTS.Server.Data.Repositiries.Helpers;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Server.Model.Reporting.Entities;
using FACCTS.Server.Models;
using FACCTS.Server.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;


namespace FACCTS.Server.Tests
{
    [TestClass]
    public class UnitTestSerialization
    {
        /// <summary>
        /// Get test CH130-object
        /// </summary>
        /// <returns>test CH130 object</returns>
        private CH130 getTestObject()
        {
            return new CH130();
        }

        /// <summary>
        /// Initialization of CH130 object
        /// </summary>
        /// <param name="testObject">Test CH130-object</param>
        /// <returns></returns>
        private CH130 Initialization(CH130 testObject)
        {
            testObject.CAPROSEntrySection = new CAPROSEntry();
            testObject.CAPROSEntrySection.CARPOSEntryType = CARPOSEntryType.ByProtected;
            testObject.CAPROSEntrySection.LawEnforcementAgencies = new List<DataItem>();
            testObject.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency1", Description = "Address1" });
            testObject.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency2", Description = "Address2" });
            testObject.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency3", Description = "Address3" });
            testObject.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency4", Description = "Address4" });
            testObject.CAPROSEntrySection.LawEnforcementAgencies.Add(new DataItem { Name = "Agency5", Description = "Address5" });

            //IDataManager dm = new DataManager( new RepositoryProvider(new RepositoryFactories()));
            //CaseHistory cc = dm.CaseHistoryRepository.GetAll().FirstOrDefault();
            //testObject.CaseHistoryId = cc.Id;
            testObject.CaseHistoryId = 160;

            testObject.ConductChoice = new CHConductChoice();
            testObject.ConductChoice.IsNoAbuse = true;
            testObject.ConductChoice.IsNoContact = true;
            testObject.ConductChoice.IsDontTryToLocate = true;
            testObject.ConductChoice.IsOtherAttached = true;
            testObject.ConductChoice.IsInvolveOther = true;
            testObject.ConductChoice.IsInvolveOtherProtected = true;
            testObject.ConductChoice.OtherDescription = "Some Description";

            testObject.IsExpire = true;

            testObject.IsNoGuns = true;

            testObject.IsOtherOrdersAttached = true;

            testObject.IsPOSGeneral = true;

            testObject.LawersFeeAndCourtCostsSection.IsEnabled = true;
            testObject.LawersFeeAndCourtCostsSection.IsCourtCosts = true;
            testObject.LawersFeeAndCourtCostsSection.IsLawyerFee = true;

            testObject.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency1", Description = "Cost1" });
            testObject.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency2", Description = "Cost2" });
            testObject.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency3", Description = "Cost3" });
            testObject.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency4", Description = "Cost4" });
            testObject.LawersFeeAndCourtCostsSection.LawyersFees.Add(new DataItem { Name = "Agency5", Description = "Cost5" });

            testObject.NoServiceFeeSection = new NoServiceFee();
            testObject.NoServiceFeeSection.IsOrdered = true;
            testObject.NoServiceFeeSection.IsBasedOnViolence = true;
            testObject.NoServiceFeeSection.IsFeeWaiver = true;

            testObject.OrdersEndDate = new Nullable<DateTime>(DateTime.Now.Date.Add(new TimeSpan(2, 5, 15)));

            testObject.OrdersEndTime = new Nullable<DateTime>(DateTime.Now.Date.Add(new TimeSpan(20, 5, 15)));

            testObject.OtherOrderDetail = "Some Details ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt";

            testObject.StayAwayOrders = new CHStayAwayOrders();
            //testObject.StayAwayOrders.IsEnabled = true;
            testObject.StayAwayOrders.IsStayAwayFromChildCare = true;
            testObject.StayAwayOrders.IsStayAwayFromChildSchool = true;
            testObject.StayAwayOrders.IsStayAwayFromHome = true;
            testObject.StayAwayOrders.IsStayAwayFromWork = true;
            testObject.StayAwayOrders.IsStayAwayFromPerson = true;
            testObject.StayAwayOrders.IsStayAwayFromVehicle = true;
            testObject.StayAwayOrders.IsAttachOther = true;
            testObject.StayAwayOrders.IsStayAwayFromOther = true;
            testObject.StayAwayOrders.OtherDescription = "Some description";
            testObject.StayAwayOrders.IsStayAwayFromOtherProtected = true;
            testObject.StayAwayOrders.StayAwayDistance = 20;

            return testObject;
        }

        /// <summary>
        /// Serialize CH130 object to XML and save XML-file
        /// </summary>
        [TestMethod]
        public void TestSerialization()
        {
            CH130 testObject = getTestObject(); //Generic the Test Object
            testObject = Initialization(testObject); //Test initialization

            XmlSerializer testSerializer = new XmlSerializer(typeof(CH130));

            using (StreamWriter testSr = new StreamWriter("myFileName.xml"))
            {
                testSerializer.Serialize(testSr, testObject);
                testSr.Close();
            }
        }

        /// <summary>
        /// Get XML data as string from database
        /// </summary>
        /// <returns>Data for deserialization</returns>
        private string getData()
        {
            IDataManager dm = new DataManager(new RepositoryProvider(new RepositoryFactories()));

            CourtOrder order = null;
            try
            {
                order = dm.CourtOrdersRepository.GetById(2);//Need input parameter. It is "2" now, for testing.
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return order.XMLContent;
        }

        /// <summary>
        /// Deserialize XML datas to CH130 object
        /// </summary>
        [TestMethod]
        public void TestDeserialization()
        {
            CH130 newTestObject = getTestObject();
            XmlSerializer serializer = new XmlSerializer(typeof(CH130));

            string result = getData();//need parameter ID

            //Deserialize object. Function is "void", but u can return deserialized object, if it need.
            CH130 myTestObject = (CH130)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(result)));
            //return myTestObject;
        }

        /// <summary>
        /// Insert XML-data into SQL-database
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            XDocument document = null;
            try
            {
                document = XDocument.Load("myFileName.xml");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Test initializing of test object
            CourtOrder order = new CourtOrder
            {
                OrderType = CourtOrdersTypes.CH130,
                IsSigned = true,
                HearingId = 1,
                XMLContent = document.ToString()
            };

            IDataManager dm = new DataManager(new RepositoryProvider(new RepositoryFactories()));
            dm.CourtOrdersRepository.Insert(order);
            dm.Commit();
            dm.CourtOrdersRepository.SaveData<CourtOrder>(order);
            //var s = dm.CourtOrdersRepository.GetAll(); Variable to testing the result
        }
    }
}

