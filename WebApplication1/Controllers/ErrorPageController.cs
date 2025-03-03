using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {

        public ActionResult NotFound404()
        {
            return View();
        }
    }
}