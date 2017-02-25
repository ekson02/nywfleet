using System.Data.Entity.ModelConfiguration;
using NywFleet.Core.Models.Lookups;

namespace NywFleet.Data.Mapping
{
    public class LookMaintenanceCriteriaMap : EntityTypeConfiguration<LookMaintenanceCriteria>
    {
        public LookMaintenanceCriteriaMap()
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
            this.ToTable("Look_MaintenanceCriteria");
            this.Property(t => t.MaintenanceCriteriaCd).HasColumnName("MaintenanceCriteriaCd");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
        }
    }
}
