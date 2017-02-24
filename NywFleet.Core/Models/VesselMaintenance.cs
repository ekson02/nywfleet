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
        public int Voids_ResultType { get; set; }
        public string Voids_Comment { get; set; }
        public int BoatInterior_ResultType { get; set; }
        public string BoatInterior_Comment { get; set; }
        public int BoatExterior_ResultType { get; set; }
        public string BoatExterior_Comment { get; set; }
        public int PilotHouse_ResultType { get; set; }
        public string PilotHouse_Comment { get; set; }
        public int EngRoomBlower_ResultType { get; set; }
        public string EngRoomBlower_Comment { get; set; }
        public int FirePumps_ResultType { get; set; }
        public string FirePumps_Comment { get; set; }
        public int BilgePump_ResultType { get; set; }
        public string BilgePump_Comment { get; set; }
        public int BatteryChargers_ResultType { get; set; }
        public string BatteryChargers_Comment { get; set; }
        public bool? JetControls { get; set; }
        public string JetControls_Comment { get; set; }
        public  ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public  ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public  Vessel Vessel { get; set; }
    }
}
