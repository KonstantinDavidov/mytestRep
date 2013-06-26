using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace FACCTS.Server.Model
{
    public class CurrentUserResponse
    {
        public User CurrentUser { get; set; }
    }
}