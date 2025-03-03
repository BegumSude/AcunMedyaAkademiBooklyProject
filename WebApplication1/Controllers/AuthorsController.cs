using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Entities;
using BooklyProjectNew.Context;


namespace BooklyProjectNew.Controllers
{
    public class AuthorsController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            var values = context.Authors.ToList();
            return View(values);
        }

        public ActionResult DeleteAuthor(int id)
        {
            var value = context.Authors.Find(id);
            context.Authors.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author model)
        {
            context.Authors.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var value = context.Authors.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author model)
        {
            var value = context.Authors.Find(model.AuthorId);

            value.Name = model.Name;
            value.Surname = model.Surname;
            context.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}