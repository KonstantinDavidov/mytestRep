    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Race
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RaceName { get; set; }
    }
}
