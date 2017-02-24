using System;
using System.Collections.Generic;

namespace NywFleet.Core.Models
{
    public sealed class VesselEngine
    {
        public VesselEngine()
        {
            EngineMaintenanceResults = new List<EngineMaintenanceResult>();
        }

        public int VesselEngineId { get; set; }
        public int EngineId { get; set; }
        public int VesselId { get; set; }
        public string CoolantTempLow { get; set; }
        public decimal CoolantTempHeigh { get; set; }
        public decimal OilPressureIdleLow { get; set; }
        public decimal OilPressureIdleHeigh { get; set; }
        public decimal OilPressureNormalLow { get; set; }
        public decimal OilPressureNormalHeigh { get; set; }
        public ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public Engine Engine { get; set; }
        public Vessel Vessel { get; set; }
    }
}
