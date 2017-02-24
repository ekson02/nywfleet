using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class Look_MaintenanceCriteriasMap : EntityTypeConfiguration<Look_MaintenanceCriterias>
    {
        public Look_MaintenanceCriteriasMap()
        {
            // Primary Key
            this.HasKey(t => t.MaintenanceCriteriaCd);

            // Properties
            this.Property(t => t.MaintenanceCriteriaCd)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Look_MaintenanceCriterias");
            this.Property(t => t.MaintenanceCriteriaCd).HasColumnName("MaintenanceCriteriaCd");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
        }
    }
}
