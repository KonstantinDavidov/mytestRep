using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Areas.Admin.Models
{
    /// <summary> model of the user edit 
    /// </summary>
    public class EditUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Certified { get; set; }
    }
}