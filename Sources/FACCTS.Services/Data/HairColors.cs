using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class HairColors : WebApiClientBase
    {
        protected List<FACCTS.Server.Model.DataModel.HairColor> GetHairColors()
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.HairColor>>("HairColor");
        }

        public static List<HairColor> GetAll()
        {
            var values = new HairColors().GetHairColors();
            if (values == null)
                return null;
            return values.Select(x => new HairColor(x)).ToList();
        }
    }
}
