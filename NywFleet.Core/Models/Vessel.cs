using System.Collections;
using System.Collections.Generic;

namespace NywFleet.Core.Models {
    public class Vessel {
        public Vessel() {
            MaintenanceLog = new List<VesselMaintenance>();
            Engines = new List<Engine>();
        }
        public int VesselId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DossierId { get; set; }
        public ICollection<VesselMaintenance> MaintenanceLog { get; set; }
        public ICollection<Engine> Engines { get; set; }

    }
}
