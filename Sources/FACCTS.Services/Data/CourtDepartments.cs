using FACCTS.Server.Model.DataModel;
using System;
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
    }
}
