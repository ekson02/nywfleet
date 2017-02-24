using System;
using System.Collections.Generic;

namespace NywFleet.Core.Models
{
    public partial class MaintenanceCriteriaResult
    {
        public int Id { get; set; }
        public int VesselMaintenanceId { get; set; }
        public string MaintenanceCriteriaCd { get; set; }
        public bool? InspectionResult { get; set; }
        public string Comment { get; set; }
        public virtual Look_MaintenanceCriterias Look_MaintenanceCriterias { get; set; }
        public virtual VesselMaintenance VesselMaintenance { get; set; }
    }
}
