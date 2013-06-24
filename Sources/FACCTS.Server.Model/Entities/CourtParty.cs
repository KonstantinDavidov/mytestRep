using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public virtual Designation Designation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public virtual ParticipantRole ParticipantRole { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string Fax { get; set; }

        [Required]
        public virtual Sex Sex { get; set; }
        [Required]
        public virtual HairColor HairColor { get; set; }
        [Required]
        public virtual EyesColor EyesColor { get; set; }
        [Required]
        public virtual Race Race { get; set; }

        public decimal Weight { get; set; }

        public decimal HeightFt { get; set; }

        public decimal HeightIns { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public bool? HasAttorney { get; set; }

        public virtual Attorney Attorney { get; set; }

        public virtual CaseRecord CaseRecordByCourtParty1 { get; set; }

        public virtual CaseRecord CaseRecordByCourtParty2 {get; set;}

    }
}
