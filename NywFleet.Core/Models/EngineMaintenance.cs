using NywFleet.Core.Common;

namespace NywFleet.Core.Models {
    public class EngineMaintenance {
        public string Id { get; set; }
        public InspectionResult Oil { get; set; }
        public InspectionResult Coolant { get; set; }
        public InspectionResult JetBearing { get; set; }
        public InspectionResult JHPU { get; set; }
        public InspectionResult Belts { get; set; }
        public decimal CoolantTemp { get; set; }
        public decimal OilPreassureIdle { get; set; }
        public decimal OilPreassureNormal { get; set; }

        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int VesselMaintenanceId { get; set; }
        public VesselMaintenance VesselMaintenance { get; set; }



    }
}
