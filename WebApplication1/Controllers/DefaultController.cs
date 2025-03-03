using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;
using BooklyProjectNew.Entities;
using System.Threading;

namespace BooklyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCategories()
        {
            var values = context.Categories.OrderBy(x => x.CategoryId).Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultBooks()
        {
            var values = context.Books.ToList();
            return PartialView(values);
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost] // post işlemlerinde partialView kulllanamıyoruz
        public ActionResult SendMessage(Message model)
        {
            context.Messages.Add(model);
            context.SaveChanges();
            Thread.Sleep(2000);
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultBanner()
        {
            var values = context.Banners.OrderByDescending(x=>x.BannerId).Take(5).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFeatured()
        {
            var values = context.Books.Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultLatestReleases()
        {
            var values = context.Books.OrderByDescending(x => x.BookId).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultBestReview()
        {
            var values = context.Books.OrderByDescending(x=>x.Review).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultOnSale()
        {
            var values = context.Books.Where(x=>x.IsOnSale).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PhotoGallery()
        {
            var values = context.PhotoGalleries.OrderBy(x=>x.PhotoGalleryId).Take(6).ToList();
            return PartialView(values);
        }

    }
}