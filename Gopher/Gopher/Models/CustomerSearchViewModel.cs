using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.ImportExport.Domain;

namespace Gopher.Models
{
    public class CustomerSearchViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }

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