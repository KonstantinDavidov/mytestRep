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
    
    public partial class ProfileData
    {
        public string pId { get; set; }
        public string Profile { get; set; }
        public string Name { get; set; }
        public string ValueString { get; set; }
        public byte[] ValueBinary { get; set; }
    
        public virtual Profiles Profiles { get; set; }
    }
}