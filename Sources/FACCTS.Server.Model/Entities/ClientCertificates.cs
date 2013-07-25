/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace FACCTS.Server.Model.DataModel
{
    public class ClientCertificates : IEntityWithId, IEntityWithState
    {

        public string UserName { get; set; }
        
        public string Thumbprint { get; set; }
        
        public string Description { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
