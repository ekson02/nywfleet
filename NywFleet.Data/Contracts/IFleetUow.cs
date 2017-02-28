using NywFleet.Core.Models;
using NywFleet.Core.Models.Lookups;

namespace NywFleet.Data.Contracts {
    public interface IFleetUow {
        IRepository<Engine> Engines { get; }
        IRepository<Vessel> Vessels { get; }
        IRepository<LookAbnormalCondition> LookAbnormalConditions { get; }
        IRepository<LookMaintenanceCriteria> LookMaintenanceCriteria { get; }
        IRepository<VesselMaintenance> VesselMaintenance { get; }
        //IRepository<UserTest> UserTests { get; }
        //IRepository<UserTestAnswer> UserTestAnswers { get; }
        //IRepository<LookCategories> Categories { get; }
        //IRepository<LookTestTypeCodes> TestTypeCodes { get; }

        int? UserId { get; set; }

        void Commit();
    }
}