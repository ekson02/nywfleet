using System.Data.Entity.ModelConfiguration;
using NywFleet.Core.Models.Lookups;

namespace NywFleet.Data.Mapping {
    public class LookAbnormalConditionsMap : EntityTypeConfiguration<LookAbnormalCondition> {
        public LookAbnormalConditionsMap() {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            // Table & Column Mappings
            this.ToTable("Look_AbnormalConditions");

        }
    }
}
