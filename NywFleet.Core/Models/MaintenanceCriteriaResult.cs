using NywFleet.Core.Models.Lookups;

namespace NywFleet.Core.Models
{
    public  class MaintenanceCriteriaResult
    {
        public int Id { get; set; }
        public int VesselMaintenanceId { get; set; }
        public string MaintenanceCriteriaCd { get; set; }
        public bool? InspectionResult { get; set; }
        public string Comment { get; set; }
        public  LookMaintenanceCriteria LookMaintenanceCriteria { get; set; }
        public  VesselMaintenance VesselMaintenance { get; set; }
    }
}
