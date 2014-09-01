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
        // GET: /AdminUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
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
