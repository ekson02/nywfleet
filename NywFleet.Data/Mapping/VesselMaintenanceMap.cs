using System.Data.Entity.ModelConfiguration;
using NywFleet.Core.Models;

namespace NywFleet.Data.Mapping {
    public class VesselMaintenanceMap : EntityTypeConfiguration<VesselMaintenance> {
        public VesselMaintenanceMap() {
            // Primary Key
            this.HasKey(t => t.VesselMaintenanceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("VesselMaintenance");
            this.Property(t => t.VesselMaintenanceId).HasColumnName("VesselMaintenanceId");

            // Relationships
            this.HasRequired(t => t.Vessel)
                .WithMany(t => t.VesselMaintenances)
                .HasForeignKey(d => d.VesselId);

        }
    }
}
