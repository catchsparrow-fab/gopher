using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;

namespace Gopher.Model.Abstractions
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(CustomerFilter filter);
    }
}
