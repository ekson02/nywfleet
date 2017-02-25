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
        public decimal CoolantTempHigh { get; set; }
        public decimal OilPressureIdleLow { get; set; }
        public decimal OilPressureIdleHigh { get; set; }
        public decimal OilPressureNormalLow { get; set; }
        public decimal OilPressureNormalHigh { get; set; }
        public ICollection<EngineMaintenanceResult> EngineMaintenanceResults { get; set; }
        public Engine Engine { get; set; }
        public Vessel Vessel { get; set; }
    }
}
