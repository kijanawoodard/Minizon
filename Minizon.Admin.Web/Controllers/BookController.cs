using System.Web.Mvc;

namespace Minizon.Admin.Web.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
