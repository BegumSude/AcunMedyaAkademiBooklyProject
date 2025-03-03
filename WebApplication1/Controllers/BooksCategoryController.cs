using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;
using BooklyProjectNew.Entities;

namespace BooklyProjectNew.Controllers
{
    public class BooksCategoryController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            var values = context.BookCategories.ToList();
            return View(values);
        }

        public ActionResult DeleteBookCategory(int id)
        {
            var value = context.BookCategories.Find(id);
            context.BookCategories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBookCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBookCategory(BookCategories model)
        {
            context.BookCategories.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}