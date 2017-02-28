using System.Data.Entity.ModelConfiguration;
using NywFleet.Core.Models;

namespace NywFleet.Data.Mapping {
    public class EngineMaintenanceResultMap : EntityTypeConfiguration<EngineMaintenanceResult> {
        public EngineMaintenanceResultMap() {
            // Primary Key
            this.HasKey(t => t.Id);

            // Relationships
            this.HasRequired(t => t.VesselEngine)
                .WithMany(t => t.EngineMaintenanceResults)
                .HasForeignKey(d => d.VesselEngineId);
            this.HasRequired(t => t.VesselMaintenance)
                .WithMany(t => t.EngineMaintenanceResults)
                .HasForeignKey(d => d.VesselMaintenanceId);

        }
    }
}
