using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NywFleet.Core.Models;
using NywFleet.Web.Controllers.Api;

namespace NywFleet.Tests.Controllers {
    [TestClass]
    public class VesselMaintenaceControllerTest {
        [TestMethod]
        public void CreateNewTest() {
            VesselMaintenanceController controller = new VesselMaintenanceController {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            var identity = new ClaimsIdentity("unittest");
            identity.AddClaim(new Claim(ClaimTypes.Name, "test"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "7878e352-6e41-46bf-af0f-7c71eb66c519"));
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);

            var maitenance = new VesselMaintenance();
            maitenance.VesselId = 23;
            maitenance.StartFuel = 230;
            maitenance.EndFuel = 20;
            maitenance.StartHours = 330;
            maitenance.EndHours = 338;
            maitenance.EndHours = 338;
            maitenance.AbnormalConditions = "AbnormalConditions";

            maitenance.EngineMaintenanceResults = new List<EngineMaintenanceResult>()
            {
                new EngineMaintenanceResult{VesselEngineId = 78,Oil = false,Coolant = true,JetBearing = true,JHPU = true,Belts = true, CoolantTemp = 100, OilPressureIdle = 10, OilPressureNormal = 20},
                new EngineMaintenanceResult{VesselEngineId = 79,Oil = true,Coolant = true,JetBearing = false,JHPU = false,Belts = true, CoolantTemp = 101, OilPressureIdle = 10, OilPressureNormal = 20},
                new EngineMaintenanceResult{VesselEngineId = 80,Oil = true,Coolant = true,JetBearing = false,JHPU = false,Belts = true, CoolantTemp = 102, OilPressureIdle = 10, },
                new EngineMaintenanceResult{VesselEngineId = 81,Oil = true,Coolant = true,JetBearing = false,JHPU = true,Belts = true, CoolantTemp = 103, OilPressureIdle = 10, OilPressureNormal = 20},
                new EngineMaintenanceResult{VesselEngineId = 82,Oil = true,Coolant = true,JetBearing = false,JHPU = true,Belts = true, CoolantTemp = 104, OilPressureIdle = 10, OilPressureNormal = 20},
                new EngineMaintenanceResult{VesselEngineId = 83,Oil = true,Coolant = true,JetBearing = false,JHPU = true,Belts = true, CoolantTemp = 105, OilPressureNormal = 20},
                new EngineMaintenanceResult{VesselEngineId = 84,Oil = true,Coolant = true,JetBearing = false,JHPU = true,Belts = true},
            };

            maitenance.MaintenanceCriteriaResults = new List<MaintenanceCriteriaResult>()
            {
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="VOIDS", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="INTR", InspectionResult = false, Comment = "Boat Interior issue"},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="EXTERIOR"},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="PLTHUSE", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="ENGRMBLWR", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="FIREPUMPS", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="BLGPUMPS", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="BTTRCHRGRS", InspectionResult = true},
                new MaintenanceCriteriaResult{MaintenanceCriteriaCd ="JETCNTRLS", InspectionResult = true},

            };

            string output = JsonConvert.SerializeObject(maitenance, Formatting.Indented);

            var response = controller.Post(maitenance) as CreatedAtRouteNegotiatedContentResult<VesselMaintenance>;
            Assert.IsNotNull(response);
            var maintenanceValidation = response.Content;
            Assert.IsNotNull(maintenanceValidation.VesselId);

        }
    }
}
