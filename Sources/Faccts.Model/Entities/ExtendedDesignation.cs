//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using ReactiveUI;
using System.Reactive.Linq;

namespace Faccts.Model.Entities
{
    [DataContract]
    public enum ExtendedDesignation : int
    {
        [EnumMember]
        Daughter = 1,
    
        [EnumMember]
        Son = 2,
    
        [EnumMember]
        Witness = 3,
    
        [EnumMember]
        Interpreter = 4,
    
        [EnumMember]
        OtherProtected = 5
    }
}