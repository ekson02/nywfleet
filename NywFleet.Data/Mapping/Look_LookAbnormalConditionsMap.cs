using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NywFleet.Core.Models.Mapping
{
    public class Look_LookAbnormalConditionsMap : EntityTypeConfiguration<Look_LookAbnormalConditions>
    {
        public Look_LookAbnormalConditionsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Look_LookAbnormalConditions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
        }
    }
}
