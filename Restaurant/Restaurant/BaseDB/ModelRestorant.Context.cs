﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.BaseDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestaurantEnt : DbContext
    {
        public RestaurantEnt()
            : base("name=RestaurantEnt")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Check_All> Check_All { get; set; }
        public virtual DbSet<Checks> Checks { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Position> Position { get; set; }
    }
}
