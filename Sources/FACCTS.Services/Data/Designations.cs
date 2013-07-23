using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class Designations : WebApiClientBase
    {
        protected List<FACCTS.Server.Model.DataModel.Designation> GetDsiagnations()
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.Designation>>("Designation");
        }

        public static List<Faccts.Model.Entities.Designation> GetAll()
        {
            var values = new Designations().GetDsiagnations();
            if (values == null)
                return null;
            return values.Select(x => new Faccts.Model.Entities.Designation(x)).ToList();
        }
    }
}
