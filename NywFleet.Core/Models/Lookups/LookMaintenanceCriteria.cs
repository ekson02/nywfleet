using System.Collections.Generic;

namespace NywFleet.Core.Models.Lookups {
    public class LookMaintenanceCriteria {
        public LookMaintenanceCriteria() {
            MaintenanceCriteriaResults = new List<MaintenanceCriteriaResult>();
        }

        public string MaintenanceCriteriaCd { get; set; }
        public string DisplayName { get; set; }
        public int DisplaySeq { get; set; }
        public bool IsActive { get; set; }

        public ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
    }
}
