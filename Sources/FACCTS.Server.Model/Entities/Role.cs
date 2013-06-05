using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Role
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [CsvField(Index = 0)]
        public int RoleId { get; set; }

        [Required]
        [CsvField(Index = 1)]
        [StringLength(50)]
        public string RoleName { get; set; }

        [CsvField(Ignore = true)]
        public string Description { get; set; }

        [CsvField(Index = 2)]
        [Required]
        public bool IsIdentityServerUser { get; set; }

        [CsvField(Ignore = true)]
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}