using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;


namespace BooklyProject.Controllers
{
    public class DashboardController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            //ViewBag geçici, dinamik bir veri taşıma aracıdır. Her tipte veri taşınabilir. Controller/View -> View

            ViewBag.bookCount = context.Books.Count();
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.authorCount = context.Authors.Count();
            ViewBag.testimonialCount = context.Testimonials.Count();

            ViewBag.avgPrice = context.Books.Average(x => x.Price).ToString("000.00");
            ViewBag.mostExpensiveBook = context.Books.OrderByDescending(x => x.Price).Select(x => x.BookName).FirstOrDefault();
            ViewBag.cheapestBook = context.Books.OrderBy(x => x.Price).Select(x => x.BookName).FirstOrDefault();
            ViewBag.onSale = context.Books.Where(x => x.IsOnSale).Count();

            return View();
        }

        public PartialViewResult BookList()
        {

            var values = context.Books.ToList();
            return PartialView(values);

        }
    }
}