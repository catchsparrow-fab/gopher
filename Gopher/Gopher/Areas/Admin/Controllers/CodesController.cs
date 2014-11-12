using System;
using System.Web.Mvc;
using Gopher.Model.Domain;
using Gopher.Model.Repositories;
using Gopher.Tools;

namespace Gopher.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CodesController : Controller
    {
        private readonly IShopRepository repository;

        public CodesController(IShopRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /AdminCodes/
        public ActionResult Index()
        {
            ViewBag.ActiveTab = "codes";
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View("Edit");
        }

        //
        // POST: /AdminUsers/Create
        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Add(shop);

                    return RedirectToAction("Index");
                }

                return View("Edit");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FatalError", Helper.ErrorMessage(ex));
                return View("Edit");
            }
        }

        //
        // GET: /AdminUsers/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.GetSingle(id);

            if (model == null)
                return new HttpNotFoundResult("Shop not found.");

            return View(model);
        }

        //
        // POST: /AdminUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(Shop shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(shop);

                    return RedirectToAction("Index");
                }

                return View(shop);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FatalError", Helper.ErrorMessage(ex));
                return View(shop);
            }
        }

        //
        // POST: /AdminUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fatal error", Helper.ErrorMessage(ex));
                var user = repository.GetSingle(id);
                if (user != null)
                    return View("Edit", user);
                return View("Edit");
            }
        }
    }
}
