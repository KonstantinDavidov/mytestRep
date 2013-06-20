using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class Sexes : WebApiClientBase
    {
        protected List<FACCTS.Server.Model.DataModel.Sex> GetSexes()
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.Sex>>("Sex");
        }

        public static List<Faccts.Model.Entities.Sex> GetAll()
        {
            var values = new Sexes().GetSexes();
            if (values == null)
                return null;

            return values.Select(x => new Faccts.Model.Entities.Sex(x)).ToList();
        }
    }
}
