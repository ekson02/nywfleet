using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class VesselMaintenanceMap : EntityTypeConfiguration<VesselMaintenance>
    {
        public VesselMaintenanceMap()
        {
            // Primary Key
            this.HasKey(t => t.VesselMaintenanceId);

            // Properties
            // Table & Column Mappings
            this.ToTable("VesselMaintenances");
            this.Property(t => t.VesselMaintenanceId).HasColumnName("VesselMaintenanceId");
            this.Property(t => t.VesselId).HasColumnName("VesselId");
            this.Property(t => t.UsersId).HasColumnName("UsersId");
            this.Property(t => t.MaintenanceDate).HasColumnName("MaintenanceDate");
            this.Property(t => t.StartHours).HasColumnName("StartHours");
            this.Property(t => t.EndHours).HasColumnName("EndHours");
            this.Property(t => t.StartFuel).HasColumnName("StartFuel");
            this.Property(t => t.EndFuel).HasColumnName("EndFuel");
            this.Property(t => t.AbnormalConditions).HasColumnName("AbnormalConditions");
            this.Property(t => t.Voids_ResultType).HasColumnName("Voids_ResultType");
            this.Property(t => t.Voids_Comment).HasColumnName("Voids_Comment");
            this.Property(t => t.BoatInterior_ResultType).HasColumnName("BoatInterior_ResultType");
            this.Property(t => t.BoatInterior_Comment).HasColumnName("BoatInterior_Comment");
            this.Property(t => t.BoatExterior_ResultType).HasColumnName("BoatExterior_ResultType");
            this.Property(t => t.BoatExterior_Comment).HasColumnName("BoatExterior_Comment");
            this.Property(t => t.PilotHouse_ResultType).HasColumnName("PilotHouse_ResultType");
            this.Property(t => t.PilotHouse_Comment).HasColumnName("PilotHouse_Comment");
            this.Property(t => t.EngRoomBlower_ResultType).HasColumnName("EngRoomBlower_ResultType");
            this.Property(t => t.EngRoomBlower_Comment).HasColumnName("EngRoomBlower_Comment");
            this.Property(t => t.FirePumps_ResultType).HasColumnName("FirePumps_ResultType");
            this.Property(t => t.FirePumps_Comment).HasColumnName("FirePumps_Comment");
            this.Property(t => t.BilgePump_ResultType).HasColumnName("BilgePump_ResultType");
            this.Property(t => t.BilgePump_Comment).HasColumnName("BilgePump_Comment");
            this.Property(t => t.BatteryChargers_ResultType).HasColumnName("BatteryChargers_ResultType");
            this.Property(t => t.BatteryChargers_Comment).HasColumnName("BatteryChargers_Comment");
           // this.Property(t => t.JetControls_ResultType).HasColumnName("JetControls_ResultType");
            this.Property(t => t.JetControls_Comment).HasColumnName("JetControls_Comment");

            // Relationships
            this.HasRequired(t => t.Vessel)
                .WithMany(t => t.VesselMaintenances)
                .HasForeignKey(d => d.VesselId);

        }
    }
}
