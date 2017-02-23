using System.Collections.Generic;

namespace NywFleet.Core.Models {
    public class Engine {
        public Engine()
        {
            EngineMaintenanceLogs=new List<EngineMaintenance>();
        }
        public int EngineId { get; set; }
        public int EngineName { get; set; }
        public List<EngineMaintenance> EngineMaintenanceLogs { get; set; }
    }
}
