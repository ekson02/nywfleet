using System;
using System.Collections.Generic;

namespace NywFleet.Core.Models
{
    public  class Vessel
    {
        public Vessel()
        {
            VesselEngines = new List<VesselEngine>();
            VesselMaintenances = new List<VesselMaintenance>();
        }

        public int VesselId { get; set; }
        public string VesselName { get; set; }
        public string ImageUrl { get; set; }
        public string DossierId { get; set; }
        public bool IsActive { get; set; }
        public ICollection<VesselEngine> VesselEngines { get; set; }
        public ICollection<VesselMaintenance> VesselMaintenances { get; set; }
    }
}
