namespace NywFleet.Core.Models {
    public class VesselEngine {
        public int VesselEngineId { get; set; }
        public int EngineId { get; set; }
        public int VesselId { get; set; }
        public string CoolantTempLow { get; set; }
        public decimal CoolantTempHeigh { get; set; }
        public decimal OilPressureIdleLow { get; set; }
        public decimal OilPressureIdleHeigh { get; set; }
        public decimal OilPressureNormalLow { get; set; }
        public decimal OilPressureNormalHeigh { get; set; }
        public Engine Engine { get; set; }
        public Vessel Vessel { get; set; }
   
    }
}
