using System.Data.Entity;
using NywFleet.Core.Models;

using NywFleet.Core.Models.Mapping;

namespace NywFleet.Data.DataContext {
    public class NYFleetContext : DbContext {
        static NYFleetContext() {
            Database.SetInitializer<NYFleetContext>(null);
        }

        public NYFleetContext()
            : base("Name=NywFleetContext") {
        }


        public int? UserId { get; set; }
        public DbSet<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Look_LookAbnormalConditions> Look_LookAbnormalConditions { get; set; }
        public DbSet<Look_MaintenanceCriterias> Look_MaintenanceCriterias { get; set; }
        public DbSet<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public DbSet<VesselEngine> VesselEngines { get; set; }
        public DbSet<VesselMaintenance> VesselMaintenances { get; set; }
        public DbSet<Vessel> Vessels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new EngineMaintenanceResultMap());
            modelBuilder.Configurations.Add(new EngineMap());
            modelBuilder.Configurations.Add(new Look_LookAbnormalConditionsMap());
            modelBuilder.Configurations.Add(new Look_MaintenanceCriteriasMap());
            modelBuilder.Configurations.Add(new MaintenanceCriteriaResultMap());
            modelBuilder.Configurations.Add(new VesselEngineMap());
            modelBuilder.Configurations.Add(new VesselMaintenanceMap());
            modelBuilder.Configurations.Add(new VesselMap());
        }

    }
}
