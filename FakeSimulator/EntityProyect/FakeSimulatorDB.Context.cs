﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<ContainerPressure> ContainerPressure { get; set; }
        public virtual DbSet<FanCapacity> FanCapacity { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}