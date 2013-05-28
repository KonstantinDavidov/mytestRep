using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{


    public partial class CourtCaseStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [CsvField(Index=0)]
        public int Id { get; set; }
        [Required]
        [CsvField(Index = 1)]
        [StringLength(100)]
        public string CaseStatus { get; set; }
    }
}
