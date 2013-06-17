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

        protected List<CourtDepartment> GetDepartmentsByCourtCounty(int courtCounty)
        {
            return this.CallServiceGet<List<CourtDepartment>>(string.Format("{0}?courtCountyId={1}", "CourtDepartments", courtCounty));
        }

        public static List<CourtDepartment> GetByCourtCountyId(CourtCounty courtCounty)
        {
            if (courtCounty == null)
            {
                return null;
            }

            return Cache.GetOrAdd(courtCounty, new CourtDepartments().GetDepartmentsByCourtCounty(courtCounty.Id));
        }

        private static ConcurrentDictionary<CourtCounty, List<CourtDepartment>> Cache = new ConcurrentDictionary<CourtCounty, List<CourtDepartment>>();
        
    }
}
