using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel
{


    public partial class Designation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DesignationName { get; set; }
    }
}
