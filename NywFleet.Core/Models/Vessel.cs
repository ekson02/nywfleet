using System.Collections.Generic;

namespace NywFleet.Core.Models {
    public class Vessel {
        public Vessel() {
            VesselMaintenance = new List<VesselMaintenance>();
            VesselEngines = new List<VesselEngine>();
        }
        public int VesselId { get; set; }
        public string VesselName { get; set; }
        public string ImageUrl { get; set; }
        public string DossierId { get; set; }
        public ICollection<VesselMaintenance> VesselMaintenance { get; set; }
        public ICollection<VesselEngine> VesselEngines { get; set; }

    }
}
