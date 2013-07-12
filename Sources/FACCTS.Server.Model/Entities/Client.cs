using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Client : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; }

        public bool AllowRefreshToken { get; set; }

        public bool AllowImplicitFlow { get; set; }

        public bool AllowResourceOwnerFlow { get; set; }

        public bool AllowCodeFlow { get; set; }

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