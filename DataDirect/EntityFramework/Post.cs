//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataDirect.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string ApproximateAddress { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public System.Data.Entity.Spatial.DbGeography Point { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
