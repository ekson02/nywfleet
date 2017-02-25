using System.Data.Entity.ModelConfiguration;
using NywFleet.Core.Models;

namespace NywFleet.Data.Mapping
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
