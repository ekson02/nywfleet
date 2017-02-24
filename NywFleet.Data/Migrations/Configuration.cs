using NywFleet.Core.Models;


namespace NywFleet.Data.Migrations {
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.NYFleetContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.NYFleetContext context) {
            //context.LookMaintenanceCriterias.AddOrUpdate(
            //      p => p.MaintenanceCriteriaCd,
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "VOIDS", DisplayName = "Voids" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "INTR", DisplayName = "Boat Interior" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "EXTERIOR", DisplayName = "Boat Exterior" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "PLTHUSE", DisplayName = "Pilot House" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "ENGRMBLWR", DisplayName = "Eng. Room Blowers" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "FIREPUMPS", DisplayName = "Fire Pumps" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "BLGPUMPS", DisplayName = "Bilge Pumps" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "BTTRCHRGRS", DisplayName = "Battery Chargers" },
            //      new LookMaintenanceCriteria() { MaintenanceCriteriaCd = "JETCNTRLS", DisplayName = "Jet Controls" }
            //    );

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
                        new Vessel { VesselName = "Hoboken" },
                        new Vessel { VesselName = "York" },
                        new Vessel { VesselName = "Jefferson" },
                        new Vessel { VesselName = "Smith" },
                        new Vessel { VesselName = "Tobin" },
                        new Vessel { VesselName = "Kean" },
                        new Vessel { VesselName = "Robert Roe" },
                        new Vessel { VesselName = "Lautenberg " },
                        new Vessel { VesselName = "Freedom " },
                        new Vessel { VesselName = "Washington " },
                        new Vessel { VesselName = "Brooklyn " }

                );

        }
    }
}
