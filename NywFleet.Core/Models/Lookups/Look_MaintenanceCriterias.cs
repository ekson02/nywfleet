using System;
using System.Collections.Generic;

namespace NywFleet.Core.Models
{
    public partial class Look_MaintenanceCriterias
    {
        public Look_MaintenanceCriterias()
        {
            this.MaintenanceCriteriaResults = new List<MaintenanceCriteriaResult>();
        }

        public string MaintenanceCriteriaCd { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
    }
}
