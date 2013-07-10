using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("Attorneys")]
    public partial class Attorney
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirmName { get; set; }

        [StringLength(200)]
        public string StreetAddress { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public USAState State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string StateBarId { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }


    }
}
