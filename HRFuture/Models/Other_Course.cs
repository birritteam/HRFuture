//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRFuture.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Other_Course
    {
        public int personid { get; set; }
        public string persontype { get; set; }
        public string name { get; set; }
        public string organizer { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Personal_Info Personal_Info { get; set; }
    }
}
