//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FACCTS.Server.Model.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Roles
    {
        public Roles()
        {
            this.UsersInRoles = new HashSet<UsersInRoles>();
        }
    
        public string Rolename { get; set; }
        public string ApplicationName { get; set; }
    
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
