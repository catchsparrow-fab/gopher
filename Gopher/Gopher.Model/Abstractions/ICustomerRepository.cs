﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
using Gopher.Model.Domain;

namespace Gopher.Model.Abstractions
{
    public interface ICustomerRepository
    {
        CustomersDataset GetCustomers(CustomerFilter filter);
    }
}
