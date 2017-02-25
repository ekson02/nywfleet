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
        public bool? Voids { get; set; }
        public string VoidsComment { get; set; }
        public bool? BoatInterior { get; set; }
        public string BoatInteriorComment { get; set; }
        public bool? BoatExterior { get; set; }
        public string BoatExteriorComment { get; set; }
        public bool? PilotHouse { get; set; }
        public string PilotHouseComment { get; set; }
        public bool? EngRoomBlower { get; set; }
        public string EngRoomBlowerComment { get; set; }
        public bool? FirePumps { get; set; }
        public string FirePumpsComment { get; set; }
        public bool? BilgePump { get; set; }
        public string BilgePumpComment { get; set; }
        public bool? BatteryChargers { get; set; }
        public string BatteryChargersComment { get; set; }
        public bool? JetControls { get; set; }
        public string JetControlsComment { get; set; }
        public  ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public  ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public  Vessel Vessel { get; set; }
    }
}
