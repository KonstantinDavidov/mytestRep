using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtSettings : IEntityWithId, IEntityWithState
    {
        public long Id { get; set;}

        [NotMapped]
        public ObjectState State { get; set;}

        public CourtCounty CourtCounty { get; set; }

        public string PrimaryCourtId { get; set; }

        public USAState IssuingState { get; set; }

        public ICollection<CourtLocation> CourtLocation { get; set; }

        public string CourtJudgename { get; set; }
        public string CourtCEOName { get; set; }

        public virtual ICollection<CourtDepartment> CourtDepartments { get; set; }
        public virtual ICollection<CourtAgency> CourtAgencies { get; set; }

    }
}
