using NywFleet.Core.Models;
using NywFleet.Core.Models.Lookups;


namespace NywFleet.Data.Migrations {
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.NyFleetContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.NyFleetContext context) {
            context.LookMaintenanceCriteria.AddOrUpdate(
                  p => p.MaintenanceCriteriaCd,
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "VOIDS", DisplayName = "Voids", DisplaySeq = 1, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "INTR", DisplayName = "Boat Interior", DisplaySeq = 2, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "EXTERIOR", DisplayName = "Boat Exterior", DisplaySeq = 3, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "PLTHUSE", DisplayName = "Pilot House", DisplaySeq = 4, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "ENGRMBLWR", DisplayName = "Eng. Room Blowers", DisplaySeq = 5, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "FIREPUMPS", DisplayName = "Fire Pumps", DisplaySeq = 6, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "BLGPUMPS", DisplayName = "Bilge Pumps", DisplaySeq = 7, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "BTTRCHRGRS", DisplayName = "Battery Chargers", DisplaySeq = 8, IsActive = true },
                  new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "JETCNTRLS", DisplayName = "Jet Controls", DisplaySeq = 9, IsActive = true }
                );


            context.LookAbnormalConditions.AddOrUpdate(
                p => p.DisplayName,
                        new LookAbnormalCondition { DisplayName = "Water leaked on Bilge Pump" },
                        new LookAbnormalCondition { DisplayName = "Low Oil Pressure" }
                );


            context.Engines.AddOrUpdate(
                p => p.EngineName,
                        new Engine { EngineName = "Port Fwd" },
                        new Engine { EngineName = "Port Aft" },
                        new Engine { EngineName = "Center Eng" },
                        new Engine { EngineName = "Strbd Aft" },
                        new Engine { EngineName = "Strbd Fwd" },
                        new Engine { EngineName = "Port Gen" },
                        new Engine { EngineName = "Strbd Gen" }
                );


            context.Vessels.AddOrUpdate(
                p => p.VesselName,
                        new Vessel { VesselName = "Hoboken", IsActive = true },
                        new Vessel { VesselName = "York", IsActive = true },
                        new Vessel { VesselName = "Jefferson", IsActive = true },
                        new Vessel { VesselName = "Smith", IsActive = true },
                        new Vessel { VesselName = "Tobin", IsActive = true },
                        new Vessel { VesselName = "Kean", IsActive = true },
                        new Vessel { VesselName = "Robert Roe", IsActive = true },
                        new Vessel { VesselName = "Lautenberg", IsActive = true },
                        new Vessel { VesselName = "Freedom ", IsActive = true },
                        new Vessel { VesselName = "Washington ", IsActive = true },
                        new Vessel { VesselName = "Brooklyn", IsActive = true },
                        new Vessel { VesselName = "Molly Pitcher", IsActive = true, ImageUrl = "molly-pitcher.jpg" }

                );

        }
    }
}
