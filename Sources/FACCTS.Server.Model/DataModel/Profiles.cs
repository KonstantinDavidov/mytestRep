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
    
    public partial class Profiles
    {
        public Profiles()
        {
            this.ProfileData = new HashSet<ProfileData>();
        }
    
        public string pId { get; set; }
        public string Username { get; set; }
        public string ApplicationName { get; set; }
        public Nullable<bool> IsAnonymous { get; set; }
        public Nullable<System.DateTime> LastActivityDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual ICollection<ProfileData> ProfileData { get; set; }
    }
}