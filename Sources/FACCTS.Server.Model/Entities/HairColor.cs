using CsvHelper.Configuration;
using FACCTS.Server.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public partial class HairColor : BaseEntity
    {
        [Key]
        [CsvField(Index = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }
        [Required]
        [CsvField(Index = 1)]
        [StringLength(150)]
        public string Color { get; set; }

        [NotMapped]
        [CsvField(Ignore=true)]
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
