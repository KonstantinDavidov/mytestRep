using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.ObjectModel;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Role : BaseEntity
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [CsvField(Index = 0)]
        public override long Id { get; set; }

        [CsvField(Index = 1)]
        [StringLength(50)]
        public string RoleName { get; set; }

        [CsvField(Ignore = true)]
        public string Description { get; set; }

        [CsvField(Index = 2)]
        public bool IsIdentityServerUser { get; set; }

        [CsvField(Ignore = true)]
        public virtual ICollection<User> Users { get; set; }

        private ICollection<Permission> _permissions;

        public virtual ICollection<Permission> Permissions 
        {
            get
            {
                return _permissions ?? new Collection<Permission>();
            }
            set
            {
                _permissions = value;
            } 
        }

        [NotMapped]
        [CsvField(Ignore = true)]
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