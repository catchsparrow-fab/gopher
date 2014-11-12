using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.ImportExport.Domain;

namespace Gopher.Models
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int? NextPage { get; set; }
        public int? PrevPage { get; set; }
        public int? FirstPage { get; set; }
        public int? LastPage { get; set; }

        public PaginationViewModel()
        {
            EndPage = -1;
        }
    }

    public class CustomerSearchViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        public CustomerFilter Filter { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<string> Prefectures { get; set; }
        public IEnumerable<Shop> Shops { get; set; }

        public CustomerSearchViewModel()
        {
            
        }

        public CustomerSearchViewModel(IEnumerable<Customer> customers)
        {
            Customers = from c in customers
                        select new CustomerViewModel(c);
        }
    }
}