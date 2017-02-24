using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class EngineMaintenanceResultMap : EntityTypeConfiguration<EngineMaintenanceResult>
    {
        public EngineMaintenanceResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("EngineMaintenanceResults");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VesselEngineId).HasColumnName("VesselEngineId");
            this.Property(t => t.VesselMaintenanceId).HasColumnName("VesselMaintenanceId");
            this.Property(t => t.Oil).HasColumnName("Oil");
            this.Property(t => t.Coolant).HasColumnName("Coolant");
            this.Property(t => t.JetBearing).HasColumnName("JetBearing");
            this.Property(t => t.JHPU).HasColumnName("JHPU");
            this.Property(t => t.Belts).HasColumnName("Belts");
            this.Property(t => t.CoolantTemp).HasColumnName("CoolantTemp");
            this.Property(t => t.OilPreassureIdle).HasColumnName("OilPreassureIdle");
            this.Property(t => t.OilPreassureNormal).HasColumnName("OilPreassureNormal");

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
