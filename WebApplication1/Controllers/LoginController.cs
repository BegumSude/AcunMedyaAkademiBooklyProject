using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using BooklyProjectNew.Entities;
using BooklyProjectNew.Context;

namespace BooklyProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        BooklyContext context = new BooklyContext();

        [HttpGet]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin model)
        {
            var admin = context.Admins.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(admin.UserName, false);
            Session["currentUser"] = admin.UserName;
            return RedirectToAction("Index", "Category");


        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}