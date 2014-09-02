using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Models;

namespace Gopher.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //
        // GET: /AdminUsers/
        public ActionResult Index()
        {
            var model = new UserListViewModel();
            model.Users = userRepository.GetAll();

            ViewBag.ActiveTab = "users";

            return View(model);
        }

        //
        // GET: /AdminUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminUsers/Create
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
        // GET: /AdminUsers/Edit/5
        public ActionResult Edit(string id)
        {
            var model = userRepository.GetSingle(id);

            if (model == null)
                return new HttpNotFoundResult("User not found.");

            return View(model);
        }

        //
        // POST: /AdminUsers/Edit/5
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
        // GET: /AdminUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AdminUsers/Delete/5
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
