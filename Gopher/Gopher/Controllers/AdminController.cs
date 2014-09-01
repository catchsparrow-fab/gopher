using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gopher.Models;

namespace Gopher.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Users()
        {
            var model = new UserListViewModel();
            var dbContext = new ApplicationDbContext();

            model.Users = from user in dbContext.Users
                          select new UserItem()
                          {
                              Id = user.Id,
                              Name = user.UserName
                          };

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