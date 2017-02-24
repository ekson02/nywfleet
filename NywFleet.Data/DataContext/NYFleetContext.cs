using System.Data.Entity;
using NywFleet.Core.Models;
using NywFleet.Core.Models.Lookups;

namespace NywFleet.Data.DataContext {
    public class NYFleetContext : DbContext {
        static NYFleetContext() {
            Database.SetInitializer<NYFleetContext>(null);
        }

        public NYFleetContext()
            : base("Name=NywFleetContext") {
        }


        public DbSet<Engine> Engines { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<VesselMaintenance> VesselMaintenances { get; set; }
        public DbSet<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        //public DbSet<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public DbSet<VesselEngine> VesselEngine { get; set; }
        public DbSet<LookMaintenanceCriteria> LookMaintenanceCriterias { get; set; }
        public DbSet<LookAbnormalCondition> LookAbnormalConditions { get; set; }



        public int? UserId { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<LookMaintenanceCriteria>().HasKey(p => p.MaintenanceCriteriaCd);
            modelBuilder.Entity<LookMaintenanceCriteria>().Property(p => p.MaintenanceCriteriaCd).HasMaxLength(10);
            modelBuilder.Entity<LookMaintenanceCriteria>().ToTable("Look_MaintenanceCriterias");
            modelBuilder.Entity<LookAbnormalCondition>().ToTable("Look_LookAbnormalConditions");
            modelBuilder.Entity<Vessel>().HasMany(i => i.VesselMaintenance).WithRequired().WillCascadeOnDelete(false);

           //modelBuilder.Entity<VesselMaintenance>().HasMany(i => i.EngineMaintenanceResults).WithOptional().WillCascadeOnDelete(false);
        }
    }
}
