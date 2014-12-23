using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Tools;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Model.Repositories;
using Gopher.Model.Tools;
using Gopher.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gopher.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerRepository repository;
        private readonly IPrefectureRepository prefectureRepository;
        private readonly IShopRepository shopRepository;

        public HomeController(ICustomerRepository repository, 
            IPrefectureRepository prefectureRepository,
            IShopRepository shopRepository)
        {
            this.repository = repository;
            this.prefectureRepository = prefectureRepository;
            this.shopRepository = shopRepository;
        }

        [ActionName("Index")]
        [HttpPost]
        public ActionResult CustomersIndex(CustomerSearchViewModel viewModel, string download, string search)
        {
            if (!string.IsNullOrEmpty(download))
                return DownloadCSV(viewModel.Filter);
            else // search
            {
                var data = repository.GetCustomers(viewModel.Filter);
                var model = GetEmptyCustomerSearchViewModel();
                model.Customers = data.Customers.Select(c => new CustomerViewModel(c));
                model.Filter = viewModel.Filter;
                model.PaginationViewModel = GetPaginationViewModel(data.TotalCount, viewModel.Filter.Page);
                model.TotalCount = data.TotalCount;
                return View(model);
            }
        }

        private const int PageSize = 50;

        private PaginationViewModel GetPaginationViewModel(int totalCount, int? page = 1)
        {
            var model = new PaginationViewModel();
            if (totalCount == 0) return model;

            model.CurrentPage = page != null ? page.Value : 1;
            if (page > 10)
                model.FirstPage = 1;

            int lastPage = (totalCount + 1) / PageSize + 1;

            model.StartPage = (model.CurrentPage - 1) / 10 * 10 + 1;
            model.EndPage = Math.Min(model.StartPage + 9, lastPage);

            if (page < lastPage && lastPage > model.EndPage)
                model.LastPage = lastPage;

            if (model.StartPage > 1)
                model.PrevPage = model.StartPage - 1;
            if (model.EndPage < lastPage)
                model.NextPage = model.EndPage + 1;

            return model;
        }

        private CustomerSearchViewModel GetEmptyCustomerSearchViewModel()
        {
            return new CustomerSearchViewModel
            {
                Prefectures = prefectureRepository.GetAll(),
                AllShops = GetShops()
            };
        }

        private IEnumerable<ShopViewModel> GetShops()
        {
            var shops = shopRepository.GetAll().ToList();
 
            // first add EC, then ALL Tempo-Visor shops option, then all tempo-visor shops one by one

            var ecShop = shops.Single(i => i.ImportedId == 0);
            var tempoVisorShops = shops.Where(i => i.ImportedId != 0).ToList();

            var allTempoVisorOptionValue = string.Join(",", from t in tempoVisorShops select t.Id);

            var list = new List<ShopViewModel>();

            list.Add(new ShopViewModel(ecShop.Name, ecShop.Id.ToString()));
            list.Add(new ShopViewModel(TranslationHelper.Get("Generic_AllTempoVisorShops"), allTempoVisorOptionValue));
            list.AddRange(from s in tempoVisorShops select new ShopViewModel(s.Name, s.Id.ToString()));

            return list;
        }

        public ActionResult Index()
        {
            return View(GetEmptyCustomerSearchViewModel());
        }

        public FileResult DownloadCSV(CustomerFilter filter)
        {
            filter.Count = -1;
            var data = repository.GetCustomers(filter);
            string header = string.Join(",", Format.GetHeaders());
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, ShiftJis.Encoding, 1024, true))
            {
                writer.WriteLine(header);
                foreach (var customer in data.Customers)
                {
                    writer.WriteLine(Format.ExportCustomerToString(customer));
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