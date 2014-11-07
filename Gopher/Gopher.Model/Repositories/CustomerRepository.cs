using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
using Gopher.Model.Abstractions;
using Gopher.Tools;

namespace Gopher.Model.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers(CustomerFilter filter)
        {
            return DbHelper.GetList<Customer>("GetCustomers", CommandType.StoredProc);
        }
    }
}
