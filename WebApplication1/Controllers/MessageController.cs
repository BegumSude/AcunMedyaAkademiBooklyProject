using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectNew.Entities;
using BooklyProjectNew.Context;


namespace BooklyProjectNew.Controllers
{
    public class MessageController : Controller
    {
        BooklyContext context = new BooklyContext();

        public ActionResult Index()
        {
            var values = context.Messages.ToList();


            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}