using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gopher.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gopher.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }

        [NonAction]
        public void CreateAdminRole()
        {
            IdentityRole role = new IdentityRole("Admin");
            var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            manager.Create(role);
        }

        [NonAction]
        public string AllRoles()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return string.Join(", ", manager.GetRoles(User.Identity.GetUserId()));
        }
    }
}