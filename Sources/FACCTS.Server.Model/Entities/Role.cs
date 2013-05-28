using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace FACCTS.Server.Model.DataModel
{
    public class Role
    {
        [Key]
        [Column("Id")]
        [CsvField(Index = 0)]
        public virtual Guid RoleId { get; set; }

        [Required]
        [CsvField(Index = 1)]
        public virtual string RoleName { get; set; }

        [CsvField(Ignore = true)]
        public virtual string Description { get; set; }

        [CsvField(Ignore = true)]
        public virtual ICollection<User> Users { get; set; }
    }
}