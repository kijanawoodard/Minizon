using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Minizon.Admin.Web.Models;

namespace Minizon.Admin.Web.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            var books = DocumentSession.Query<Book>().ToList();
            return View(books);
        }

        public ActionResult Details(string id)
        {
            var book = DocumentSession.Load<Book>(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                DocumentSession.Store(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(book);
            }
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Book/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
