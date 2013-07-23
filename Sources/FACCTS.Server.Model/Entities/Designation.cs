using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{


    public partial class Designation : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [CsvField(Index = 0)]
        public override long Id { get; set; }
        [CsvField(Index = 1)]
        [StringLength(150)]
        public string DesignationName { get; set; }

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
