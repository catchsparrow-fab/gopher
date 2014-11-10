using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;

namespace Gopher.Model.Domain
{
    public class CustomersDataset
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
    }
}
