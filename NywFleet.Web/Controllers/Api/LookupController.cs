using System.Linq;
using System.Web.Http;

namespace NywFleet.Web.Controllers.Api {
    [RoutePrefix("api/lookup")]
    public class LookupController : BaseApiController {

        public LookupController() {

        }

        //[AllowAnonymous]
        //[Route("test-types")]
        //public IHttpActionResult GetTestTypes() {
        //    var data = Uow.TestTypeCodes.Query().ToList();
        //    return Ok(data);
        //}


    }
}
