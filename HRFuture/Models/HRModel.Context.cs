﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HRContext : DbContext
    {
        public HRContext()
            : base("name=HRContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Best_Friends> Best_Friends { get; set; }
        public virtual DbSet<Emergency_Address> Emergency_Address { get; set; }
        public virtual DbSet<Other_Course> Other_Course { get; set; }
        public virtual DbSet<Personal_Info> Personal_Info { get; set; }
        public virtual DbSet<Personal_Skills> Personal_Skills { get; set; }
        public virtual DbSet<Skills_Info> Skills_Info { get; set; }
    }
}