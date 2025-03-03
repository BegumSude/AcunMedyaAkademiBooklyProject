using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Entities;
using BooklyProjectNew.Context;
using System.IO;
using BooklyProjectNew.Models;

namespace BooklyProjectNew.Controllers
{
    public class ProfileController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            string userName = Session["currentUser"].ToString();
            var user = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Admin model)
        {
            string userName = Session["currentUser"].ToString();
            var user = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();
            if (model.Password != user.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz Şifre Hatalı!");
                return View(user);
            }
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                user.ImageUrl = "/images/" + model.ImageFile.FileName;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;

            context.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            string userName = Session["currentUser"].ToString();
            var user = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();

            if (model.CurrentPassword != user.Password)
            {
                ModelState.AddModelError(string.Empty, "Mevcut şifreniz hatalı!");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                return View(model);
            }

            user.Password = model.ConfirmPassword;
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
            
        }
    }
       
}