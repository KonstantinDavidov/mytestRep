/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace FACCTS.Server.Model.DataModel
{
    public partial class ClientCertificates : BaseEntity
    {

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Thumbprint { get; set; }
        
        [Required]
        public string Description { get; set; }

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
