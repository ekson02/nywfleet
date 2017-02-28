using System;
using System.Collections.Generic;

namespace NywFleet.Core.Models
{
    public class VesselMaintenance
    {
        public VesselMaintenance()
        {
            EngineMaintenanceResults = new List<EngineMaintenanceResult>();
            MaintenanceCriteriaResults = new List<MaintenanceCriteriaResult>();
        }

        public int VesselMaintenanceId { get; set; }
        public int VesselId { get; set; }
        public string UsersId { get; set; }
        public System.DateTime MaintenanceDate { get; set; }
        public long StartHours { get; set; }
        public long EndHours { get; set; }
        public long StartFuel { get; set; }
        public long EndFuel { get; set; }
        public string AbnormalConditions { get; set; }
       
        public  ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public  ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public  Vessel Vessel { get; set; }
    }
}
