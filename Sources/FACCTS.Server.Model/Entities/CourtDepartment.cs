using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtDepartmenets")]
    public partial class CourtDepartment : BaseEntity
    {

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Room { get; set; }

        [StringLength(100)]
        public string BranchOfficer {get; set;}

        [StringLength(100)]
        public string Reporter { get; set; }

        [InverseProperty("Departments")]
        [JsonProperty(ItemIsReference = true, ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        [ForeignKey("CourtCountyId")]
        public virtual CourtCounty CourtCounty { get; set; }

        public long CourtCountyId { get; set; }

        [NotMapped]
        public override ObjectState State
        {
            get
            {
                return base.State;
            }
            set
            {
                base.State = value;
            }
        }
    }
}
