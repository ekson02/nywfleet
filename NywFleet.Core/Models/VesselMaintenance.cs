using System;
using System.Collections.Generic;
using NywFleet.Core.Common;

namespace NywFleet.Core.Models {
    public class VesselMaintenance {
        public VesselMaintenance() {
            MaintenanceCriteriaResults = new List<MaintenanceCriteriaResult>();
            EngineMaintenanceResults = new List<EngineMaintenanceResult>();
        }
        public int VesselMaintenanceId { get; set; }
        public int VesselId { get; set; }
        public string UsersId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public long StartHours { get; set; }
        public long EndHours { get; set; }
        public long StartFuel { get; set; }
        public long EndFuel { get; set; }
        public string AbnormalConditions { get; set; }
        public InspectionResult Voids { get; set; }
        public InspectionResult BoatInterior { get; set; }
        public InspectionResult BoatExterior { get; set; }
        public InspectionResult PilotHouse { get; set; }
        public InspectionResult EngRoomBlower { get; set; }
        public InspectionResult FirePumps { get; set; }
        public InspectionResult BilgePump { get; set; }
        public InspectionResult BatteryChargers { get; set; }
        public InspectionResult JetControls { get; set; }
        public ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public ICollection<MaintenanceCriteriaResult> MaintenanceCriteriaResults { get; set; }
        public Vessel Vessel { get; set; }
    }
}
