using System.Data.Entity;
using NywFleet.Core.Models;
using NywFleet.Core.Models.Lookups;
using NywFleet.Core.Models.Mapping;
using NywFleet.Data.Mapping;

namespace NywFleet.Data.DataContext {
    public class NyFleetContext : DbContext {
        static NyFleetContext() {
            Database.SetInitializer<NyFleetContext>(null);
        }

        public NyFleetContext()
            : base("Name=NywFleetContext") {
        }


        public int? UserId { get; set; }
        public DbSet<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<LookAbnormalCondition> LookAbnormalConditions { get; set; }
        public DbSet<LookMaintenanceCriteria> LookMaintenanceCriteria { get; set; }
        public DbSet<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public DbSet<VesselEngine> VesselEngines { get; set; }
        public DbSet<VesselMaintenance> VesselMaintenance { get; set; }
        public DbSet<Vessel> Vessels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new EngineMaintenanceResultMap());
            modelBuilder.Configurations.Add(new EngineMap());
            modelBuilder.Configurations.Add(new LookAbnormalConditionsMap());
            modelBuilder.Configurations.Add(new LookMaintenanceCriteriaMap());
            modelBuilder.Configurations.Add(new MaintenanceCriteriaResultMap());
            modelBuilder.Configurations.Add(new VesselEngineMap());
            modelBuilder.Configurations.Add(new VesselMaintenanceMap());
            modelBuilder.Configurations.Add(new VesselMap());
        }

    }
}
