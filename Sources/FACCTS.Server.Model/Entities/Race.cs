using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Race
    {
        [Key]
        [CsvField(Index = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [CsvField(Index = 1)]
        [StringLength(150)]
        public string RaceName { get; set; }
    }
}
