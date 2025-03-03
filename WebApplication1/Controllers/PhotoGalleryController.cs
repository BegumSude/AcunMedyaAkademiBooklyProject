using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Entities;
using BooklyProjectNew.Context;

namespace BooklyProjectNew.Controllers
{
    public class PhotoGalleryController : Controller
    {

        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }

        public ActionResult DeletePhoto(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery Model)
        {
            context.PhotoGalleries.Add(Model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery Model)
        {
            var value = context.PhotoGalleries.Find(Model.PhotoGalleryId);

            value.ImageUrl = Model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}