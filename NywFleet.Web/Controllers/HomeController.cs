﻿using System.Web.Mvc;

namespace NywFleet.Web.Controllers {
    public class HomeController : Controller {
        [Authorize]
        public ActionResult Index() {
            return View();
        }

    }
}