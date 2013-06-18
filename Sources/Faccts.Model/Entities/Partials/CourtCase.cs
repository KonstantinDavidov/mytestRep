using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCase
    {
        public CourtCase(FACCTS.Server.Model.DataModel.CourtCase courtCaseDto)
        {
            this.CaseNumber = courtCaseDto.CaseNumber;
            this.Id = courtCaseDto.Id;

            this.CCPORId = courtCaseDto.CCPORId;
            this.CCPORStatus = (int?)courtCaseDto.CCPORStatus;
            RaiseNavigationPropertyLoading(() => User);
            RaiseNavigationPropertyLoading(() => CaseRecord);
        }
    }
}
