using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Models;

namespace Gopher.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository userRepository;

        public AdminController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Users()
        {
            var model = new UserListViewModel();
            model.Users = userRepository.GetAll();

            ViewBag.ActiveTab = "users";

            return View(model);
        }

        public ActionResult Codes()
        {
            ViewBag.ActiveTab = "codes";
            return View();
        }
    }
}