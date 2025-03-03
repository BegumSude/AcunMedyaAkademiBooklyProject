using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;

namespace BooklyProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLayoutNavbar()
        {
            var userName = Session["currentUser"];

            ViewBag.nameSurname = context.Admins.Where(x => x.UserName == userName).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();

            ViewBag.imageUrl = context.Admins.Where(x => x.UserName == userName).Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }
    }
}