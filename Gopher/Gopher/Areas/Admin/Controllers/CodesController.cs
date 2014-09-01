using System.Web.Mvc;

namespace Gopher.Areas.Admin.Controllers
{
    public class CodesController : Controller
    {
        //
        // GET: /AdminCodes/
        public ActionResult Index()
        {
            ViewBag.ActiveTab = "codes";
            return View();
        }

        //
        // GET: /AdminCodes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AdminCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminCodes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminCodes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AdminCodes/Edit/5
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
        // GET: /AdminCodes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AdminCodes/Delete/5
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
