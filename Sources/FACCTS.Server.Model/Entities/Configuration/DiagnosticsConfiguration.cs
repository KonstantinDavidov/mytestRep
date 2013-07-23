using System;
using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public class DiagnosticsConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean EnableFederationMessageTracing { get; set; }
    }
}
