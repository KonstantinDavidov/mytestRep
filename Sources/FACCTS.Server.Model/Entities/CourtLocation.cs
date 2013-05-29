using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtLocations")]
    public partial class CourtLocation
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(200)]
        public string StreetAddress { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [InverseProperty("CourtLocations")]
        public virtual CourtCounty CourtCounty { get; set; }

        [InverseProperty("CourtLocation")]
        public virtual ICollection<Courtroom> Courtrooms { get; set; }
    }
}
