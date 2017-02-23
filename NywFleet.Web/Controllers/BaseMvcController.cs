using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using NywFleet.Data;

namespace NywFleet.Web.Controllers {
    public class BaseMvcController : Controller {
        readonly FleetUow _uow;
        protected static ILog GlLoger = LogManager.GetLogger(typeof(Controller));
        public FleetUow Uow => _uow;
        public string CurrentUserId => User.Identity.GetUserId();
        public BaseMvcController() {
            _uow = new FleetUow();

        }

        protected override void Dispose(bool disposing) {
            _uow?.Dispose();
            base.Dispose(disposing);
        }

    }

}
