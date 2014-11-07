using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Gopher.ImportExport.Tools;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gopher.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerRepository repository;

        public HomeController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public FileResult DownloadCSV()
        {
            string header = string.Join(",", Format.GetHeaders());
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                writer.WriteLine(header);
                foreach (var customer in repository.GetCustomers(null))
                {
                    writer.WriteLine(Format.CustomerToString(customer));
                }
            }

            stream.Position = 0;
            
            return File(stream, "text/csv", "gopher-db-" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }

        //[HttpPost]
        //[ActionName("Import")]
        //public ActionResult UploadFile()
        //{
        //    return View(); 
        //}

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