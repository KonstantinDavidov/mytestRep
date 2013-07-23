using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class Races : WebApiClientBase
    {
        protected List<FACCTS.Server.Model.DataModel.Race> GetRaces()
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.Race>>("Race");
        }

        public static List<Faccts.Model.Entities.Race> GetAll()
        {
            var values = new Races().GetRaces();
            if (values == null)
                return null;
            return values.Select(x => new Faccts.Model.Entities.Race(x)).ToList();
        }
    }
}
