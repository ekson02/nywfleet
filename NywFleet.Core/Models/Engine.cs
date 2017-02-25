using System.Collections.Generic;

namespace NywFleet.Core.Models {
    public class Engine {
        public int EngineId { get; set; }
        public string EngineName { get; set; }
        public ICollection<VesselEngine> VesselEngines { get; set; }
    }
}
