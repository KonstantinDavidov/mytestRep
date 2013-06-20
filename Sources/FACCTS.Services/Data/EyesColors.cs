using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class EyesColors : WebApiClientBase
    {
        protected List<FACCTS.Server.Model.DataModel.EyesColor> GetEyesColors()
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.EyesColor>>("EyesColor");
        }

        public static List<EyesColor> GetAll()
        {
            var dtos = new EyesColors().GetEyesColors();
            if (dtos == null)
                return null;

            return dtos.Select(x => new EyesColor(x)).ToList();
        }
    }
}
