using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping {
    public class MaintenanceCriteriaResultMap : EntityTypeConfiguration<MaintenanceCriteriaResult> {
        public MaintenanceCriteriaResultMap() {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MaintenanceCriteriaCd)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MaintenanceCriteriaResults");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VesselMaintenanceId).HasColumnName("VesselMaintenanceId");
            this.Property(t => t.MaintenanceCriteriaCd).HasColumnName("MaintenanceCriteriaCd");
            this.Property(t => t.InspectionResult).HasColumnName("InspectionResult");
            this.Property(t => t.Comment).HasColumnName("Comment");

            // Relationships
            this.HasOptional(t => t.LookMaintenanceCriteria)
                .WithMany(t => t.MaintenanceCriteriaResults)
                .HasForeignKey(d => d.MaintenanceCriteriaCd);
            this.HasRequired(t => t.VesselMaintenance)
                .WithMany(t => t.MaintenanceCriteriaResults)
                .HasForeignKey(d => d.VesselMaintenanceId);

        }
    }
}
