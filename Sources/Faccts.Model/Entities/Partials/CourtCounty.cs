using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCounty : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtCounty>
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

        public FACCTS.Server.Model.DataModel.CourtCounty ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtCounty()
            {
                Id = this.Id,
                CourtCode = this.court_code,
                County = this.county,
                CourtName = this.court_name,
                Location = this.location,
                CourtLocations = this.CourtLocations.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Departments = this.CourtDepartmenets.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
