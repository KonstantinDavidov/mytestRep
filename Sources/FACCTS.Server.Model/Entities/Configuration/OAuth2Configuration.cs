using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public class OAuth2Configuration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public bool EnableConsent { get; set; }
        public bool EnableResourceOwnerFlow { get; set; }
        public bool EnableImplicitFlow { get; set; }
        public bool EnableCodeFlow { get; set; }
    }
}
