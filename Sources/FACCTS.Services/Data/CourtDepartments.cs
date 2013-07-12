using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtDepartments : WebApiClientBase
    {
        protected CourtDepartments() : base()
        {

        }

        protected List<CourtDepartment> GetDepartments()
        {
            return this.CallServiceGet<List<CourtDepartment>>("CourtDepartments");
        }

        protected List<CourtDepartment> GetDepartmentsByCourtCounty(long courtCounty)
        {
            return this.CallServiceGet<List<CourtDepartment>>(string.Format("{0}?courtCountyId={1}", "CourtDepartments", courtCounty));
        }

        public static List<Faccts.Model.Entities.CourtDepartmenets> GetByCourtCountyId(long?  courtCountyId)
        {
            if (courtCountyId == null)
            {
                return null;
            }
            return Cache.GetOrAdd(courtCountyId.GetValueOrDefault(), new CourtDepartments().GetDepartmentsByCourtCounty(courtCountyId.GetValueOrDefault())
                .Select(d =>
                new Faccts.Model.Entities.CourtDepartmenets(d)).ToList())
                ;
        }

        private static ConcurrentDictionary<long, List<Faccts.Model.Entities.CourtDepartmenets>> Cache = new ConcurrentDictionary<long, List<Faccts.Model.Entities.CourtDepartmenets>>();
        
    }
}
