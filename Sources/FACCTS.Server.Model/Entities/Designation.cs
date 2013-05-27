using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel
{


    public partial class Designation
    {
        [Key]
        [CsvField(Index = 0)]
        public int Id { get; set; }
        [Required]
        [CsvField(Index = 1)]
        public string DesignationName { get; set; }
    }
}
