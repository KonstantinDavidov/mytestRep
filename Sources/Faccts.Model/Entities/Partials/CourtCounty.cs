using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCounty
    {

        public CourtCounty(FACCTS.Server.Model.DataModel.CourtCounty dtoCounty) : this()
        {
            if (dtoCounty == null)
            {
                throw new ArgumentNullException("dtoCounty");
            }
            this.Id = dtoCounty.Id;
            this.court_code = dtoCounty.CourtCode;
            this.county = dtoCounty.County;
            this.court_name = dtoCounty.CourtName;
            this.location = dtoCounty.Location;
            this.RaiseNavigationPropertyLoading(() => CourtLocations);
        }
    }
}
