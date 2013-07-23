using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public class SimpleHttpConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }
    }
}
