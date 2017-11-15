namespace EntityProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntitiesContext : DbContext
    {
        public EntitiesContext()
            : base("name=EntitiesContext")
        {
        }

        public virtual DbSet<SimulationConfiguration> SimulationConfigurations { get; set; }
        public virtual DbSet<ContainerPressure> ContainerPressures { get; set; }
        public virtual DbSet<FanCapacity> FanCapacities { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimulationConfiguration>()
                .Property(e => e.OneHourInterval)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ContainerPressure>()
                .Property(e => e.Width)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ContainerPressure>()
                .Property(e => e.Height)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FanCapacity>()
                .Property(e => e.Radius)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FanCapacity>()
                .Property(e => e.BladeLength)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Material>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Material>()
                .Property(e => e.Resistence)
                .HasPrecision(8, 5);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.IdMaterial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.ContainerPressure)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.IdModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.FanCapacity)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.IdModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Report1)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
