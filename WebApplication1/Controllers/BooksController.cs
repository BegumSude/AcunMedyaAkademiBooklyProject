using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Context;
using BooklyProjectNew.Entities;

namespace BooklyProjectNew.Controllers
{

    public class BooksController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index(string searchText)
        {
            List<Book> values;

            if (searchText != null)
            {
                values = context.Books.Where(x => x.BookName.Contains(searchText)).ToList();
                return View(values);
            }
            values = context.Books.ToList();
            return View(values);
        }

        public ActionResult DeleteBook(int id)
        {
            var value = context.Books.Find(id);
            context.Books.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            context.Books.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var value = context.Books.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBook(Book model)
        {
            var value = context.Books.Find(model.BookId);

            value.CoverImageUrl = value.CoverImageUrl;
            value.BookName = model.BookName;
            value.Author = model.Author;
            value.Price = model.Price;

            context.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}