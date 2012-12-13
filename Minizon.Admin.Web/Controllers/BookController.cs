using System;
using System.Linq;
using System.Web.Mvc;
using Minizon.Admin.Web.Models;
using Minizon.Catalog.Messages;

namespace Minizon.Admin.Web.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            var books = DocumentSession.Query<CatalogBookViewModel>().ToList();
            return View(books);
        }

        public ActionResult Details(string id)
        {
            var book = DocumentSession.Load<CatalogBookViewModel>(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddNewBook addNewBookCommand)
        {
            try
            {
                MvcApplication.Bus.Send(addNewBookCommand);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return new ContentResult {Content = e.ToString()};
            }
        }

        public ActionResult Edit(string id)
        {
            var book = DocumentSession.Load<CatalogBookViewModel>(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(CatalogBookViewModel catalogBookViewModel)
        {
            try
            {
                // issue a command to save a CatalogBook
                DocumentSession.Store(catalogBookViewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

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
