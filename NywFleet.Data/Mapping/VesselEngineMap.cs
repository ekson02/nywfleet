using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class VesselEngineMap : EntityTypeConfiguration<VesselEngine>
    {
        public VesselEngineMap()
        {
            // Primary Key
            this.HasKey(t => t.VesselEngineId);

            // Properties
            // Table & Column Mappings
            this.ToTable("VesselEngines");
            this.Property(t => t.VesselEngineId).HasColumnName("VesselEngineId");
            this.Property(t => t.EngineId).HasColumnName("EngineId");
            this.Property(t => t.VesselId).HasColumnName("VesselId");
            this.Property(t => t.CoolantTempLow).HasColumnName("CoolantTempLow");
            this.Property(t => t.CoolantTempHeigh).HasColumnName("CoolantTempHeigh");
            this.Property(t => t.OilPressureIdleLow).HasColumnName("OilPressureIdleLow");
            this.Property(t => t.OilPressureIdleHeigh).HasColumnName("OilPressureIdleHeigh");
            this.Property(t => t.OilPressureNormalLow).HasColumnName("OilPressureNormalLow");
            this.Property(t => t.OilPressureNormalHeigh).HasColumnName("OilPressureNormalHeigh");

            // Relationships
            this.HasRequired(t => t.Engine)
                .WithMany(t => t.VesselEngines)
                .HasForeignKey(d => d.EngineId);
            this.HasRequired(t => t.Vessel)
                .WithMany(t => t.VesselEngines)
                .HasForeignKey(d => d.VesselId);

        }
    }
}
