﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAL
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class RavKav : DbContext
{
    public RavKav()
        : base("name=RavKav")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
<<<<<<< Updated upstream
        throw new UnintentionalCodeFirstException();
=======
        public RavKav()
            : base("name=RavKav")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AreaToContract> AreaToContracts { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Transit> Transits { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
>>>>>>> Stashed changes
    }


    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AreaToContract> AreaToContracts { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Transit> Transits { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

}

}

