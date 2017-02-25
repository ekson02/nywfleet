using System.Linq;
using System.Web.Http;

namespace NywFleet.Web.Controllers.Api {
    [RoutePrefix("api/lookup")]
    public class LookupController : BaseApiController {

        public LookupController() {

        }

        [AllowAnonymous]
        [Route("maintenance-criteria")]
        public IHttpActionResult GetTestTypes() {
            var data = Uow.LookMaintenanceCriteria.Query()
                .Where(p => p.IsActive)
                .OrderBy(p => p.DisplaySeq).ToList();

            return Ok(data);
        }

        [AllowAnonymous]
        [Route("abnormal-conditions")]
        public IHttpActionResult GetAbnormalConditions() {
            var data = Uow.LookAbnormalConditions.Query().OrderBy(p => p.DisplayName)
                .ToList();
            return Ok(data);
        }

    }
}
