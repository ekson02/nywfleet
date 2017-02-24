using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class VesselMap : EntityTypeConfiguration<Vessel>
    {
        public VesselMap()
        {
            // Primary Key
            this.HasKey(t => t.VesselId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Vessels");
            this.Property(t => t.VesselId).HasColumnName("VesselId");
            this.Property(t => t.VesselName).HasColumnName("VesselName");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
            this.Property(t => t.DossierId).HasColumnName("DossierId");
        }
    }
}
