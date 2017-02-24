using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class EngineMap : EntityTypeConfiguration<Engine>
    {
        public EngineMap()
        {
            // Primary Key
            this.HasKey(t => t.EngineId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Engines");
            this.Property(t => t.EngineId).HasColumnName("EngineId");
            this.Property(t => t.EngineName).HasColumnName("EngineName");
        }
    }
}
