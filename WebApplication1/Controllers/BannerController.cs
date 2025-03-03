using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;
using BooklyProjectNew.Entities;

namespace BooklyProjectNew.Controllers
{
    public class BannerController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            var values = context.Banners.ToList();
            return View(values);
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = context.Banners.Find(id);
            context.Banners.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBanner(Banner model)
        {
            context.Banners.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner model)
        {
            var value = context.Banners.Find(model.BannerId);

            value.Title = value.Title;
            value.Description = value.Description;
            value.ImageUrl = model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}