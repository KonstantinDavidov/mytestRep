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
    
    public partial class Sessions
    {
        public string SessionId { get; set; }
        public string ApplicationName { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expires { get; set; }
        public int Timeout { get; set; }
        public bool Locked { get; set; }
        public int LockId { get; set; }
        public System.DateTime LockDate { get; set; }
        public string Data { get; set; }
        public int Flags { get; set; }
    }
}
