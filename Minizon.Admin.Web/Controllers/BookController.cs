using System.Collections.Generic;
using System.Web.Mvc;
using Minizon.Admin.Web.Models;

namespace Minizon.Admin.Web.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View(MvcApplication.Books);
        }

        public ActionResult Details(int id)
        {
            return View();
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
                MvcApplication.Books.Add(book);

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
