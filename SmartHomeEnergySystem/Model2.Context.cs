﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartHomeEnergySystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbSHESEntities : DbContext
    {
        public dbSHESEntities()
            : base("name=dbSHESEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BatteryTable> BatteryTables { get; set; }
        public virtual DbSet<ConsumerTable> ConsumerTables { get; set; }
        public virtual DbSet<SolarPanelTable> SolarPanelTables { get; set; }
        public virtual DbSet<eVehicleTable> eVehicleTables { get; set; }
        public virtual DbSet<ChartTable> ChartTables { get; set; }
    }
}
