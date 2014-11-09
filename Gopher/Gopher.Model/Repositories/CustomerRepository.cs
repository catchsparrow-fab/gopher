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
            return DbHelper.GetList<Customer>("GetCustomers", CommandType.StoredProc,
                new DbParameter("customerId", filter.CustomerId),
                new DbParameter("sex", GetSexFilter(filter.Sex)),
                new DbParameter("dobMin", filter.DateOfBirth.Min),
                new DbParameter("dobMax", filter.DateOfBirth.Max),
                new DbParameter("timesPurchasedMin", filter.TimesPurchased.Min),
                new DbParameter("timesPurchasedMax", filter.TimesPurchased.Max)
                );
        }

        private static object GetSexFilter(Sex[] selected)
        {
            if (selected == null || selected.Length != 1) return null;

            return selected[0];
        }

        private static IEnumerable<DbParameter> GetParameters(CustomerFilter filter)
        {
            var list = new List<DbParameter>();
            //if (filter.
            return list;
        }
    }
}
