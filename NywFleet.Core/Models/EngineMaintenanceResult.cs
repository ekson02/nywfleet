
namespace NywFleet.Core.Models {
    public class EngineMaintenanceResult {
        public int Id { get; set; }
        public int VesselEngineId { get; set; }
        public int VesselMaintenanceId { get; set; }
        public bool? Oil { get; set; }
        public bool? Coolant { get; set; }
        public bool? JetBearing { get; set; }
        public bool? JHPU { get; set; }
        public bool? Belts { get; set; }
        public decimal? CoolantTemp { get; set; }
        public decimal? OilPressureIdle { get; set; }
        public decimal? OilPressureNormal { get; set; }
        public VesselEngine VesselEngine { get; set; }
        public VesselMaintenance VesselMaintenance { get; set; }
    }
}
