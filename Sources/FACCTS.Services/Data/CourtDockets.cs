using Faccts.Model.Entities;
using FACCTS.Server.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class CourtDockets : WebApiClientBase
    {

        public IEnumerable<DocketRecord> GetAll()
        {
            var criteria = ServiceLocatorContainer.Locator.GetInstance<ICourtDocketSearchCriteria>();
            return this
                .CallServiceGet<List<FACCTS.Server.Model.Calculations.DocketRecord>>
                (
                string.Format("{0}?{1}", Routes.CourtDocket.CourtDocketController, criteria.ToString())
                ).Select(x => new DocketRecord(x));
        }

        public static IEnumerable<DocketRecord> GetDocket()
        {
            return new CourtDockets().GetAll();
        }

        internal static void SaveDocket(IEnumerable<DocketRecord> docketRecords)
        {
            if (docketRecords.Any())
            {
                new CourtDockets().Save(
                    docketRecords.Select(x => x.ToDTO())
                );
            }
            
        }

        public void Save(IEnumerable<FACCTS.Server.Model.Calculations.DocketRecord> docketRecords)
        {
            this.CallServicePut<Object, IEnumerable<FACCTS.Server.Model.Calculations.DocketRecord>>(Routes.CourtDocket.CourtDocketController, docketRecords);
        }
    }
}
