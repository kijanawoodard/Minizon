using System.Linq;
using System.Web.Mvc;
using Minizon.Admin.Web.Models;

namespace Minizon.Admin.Web.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            var books = DocumentSession.Query<CatalogBook>().ToList();
            return View(books);
        }

        public ActionResult Details(string id)
        {
            var book = DocumentSession.Load<CatalogBook>(id);
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CatalogBook catalogBook)
        {
            try
            {
                // NSB command here
                DocumentSession.Store(catalogBook);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(catalogBook);
            }
        }

        //
        // GET: /CatalogBook/Edit/5

        public ActionResult Edit(string id)
        {
            var book = DocumentSession.Load<CatalogBook>(id);
            return View(book);        
        }

        //
        // POST: /CatalogBook/Edit/5

        [HttpPost]
        public ActionResult Edit(CatalogBook catalogBook)
        {
            try
            {
                // issue a command to save a CatalogBook
                DocumentSession.Store(catalogBook);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CatalogBook/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CatalogBook/Delete/5

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
