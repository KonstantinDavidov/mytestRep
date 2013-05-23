using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Models
{
    public class LogOnModel
    {
        [Required]
        [DisplayName("OpenID")]
        public string UserSuppliedIdentifier { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}