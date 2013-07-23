using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public partial class IdentityProvider : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public int Type { get; set; }

        [Required]
        public bool ShowInHrdSelection { get; set; }

        public string WSFederationEndpoint { get; set; }
        public string IssuerThumbprint { get; set; }
        
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public int? OAuth2ProviderType { get; set; }

        public bool Enabled { get; set; }

        [NotMapped]
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