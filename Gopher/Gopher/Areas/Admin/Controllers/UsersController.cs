using System;
using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Models;
using Gopher.Tools;

namespace Gopher.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
            return View("Edit");
        }

        //
        // POST: /AdminUsers/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepository.Add(user);

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
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepository.Update(user);

                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FatalError", Helper.ErrorMessage(ex));
                return View(user);
            }
        }

        //
        // POST: /AdminUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                userRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fatal error", Helper.ErrorMessage(ex));
                var user = userRepository.GetSingle(id);
                if (user != null)
                    return View("Edit", user);
                return View("Edit");
            }
        }
    }
}
