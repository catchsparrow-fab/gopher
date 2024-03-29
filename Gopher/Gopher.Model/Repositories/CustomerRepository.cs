﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Tools;

namespace Gopher.Model.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomersDataset GetCustomers(CustomerFilter filter)
        {
            var dataset = new CustomersDataset();
            using (var reader = DbHelper.ExecuteReader("GetCustomers", CommandType.StoredProc, GetParameters(filter).ToArray()))
            {
                var list = new List<Customer>();
                while (reader.Read())
                {
                    var item = new Customer();
                    item.Init(reader);
                    list.Add(item);
                }

                dataset.Customers = list;

                reader.NextResult();
                reader.Read();

                dataset.TotalCount = reader.GetInt32("TotalCount");
            }
            return dataset;
        }

        private static IEnumerable<DbParameter> GetParameters(CustomerFilter filter)
        {
            return new List<DbParameter>
            {
                new DbParameter("customerId", filter.CustomerId),
                new DbParameter("sex", GetSexFilter(filter.Sex)),
                new DbParameter("dobMin", filter.DateOfBirth.Min),
                new DbParameter("dobMax", filter.DateOfBirth.Max),
                new DbParameter("timesPurchasedMin", filter.TimesPurchased.Min),
                new DbParameter("timesPurchasedMax", filter.TimesPurchased.Max),
                new DbParameter("count", filter.Count),
                new DbParameter("start", GetStartingIndex(filter.Page)),
                new DbParameter("monthOfBirth", filter.MonthOfBirth),
                new DbParameter("nameKanji", filter.NameKanji),
                new DbParameter("nameKana", filter.NameKana),
                new DbParameter("email", filter.Email),
                new DbParameter("emailMobile", filter.EmailMobile),
                new DbParameter("phone", filter.Phone),
                new DbParameter("productWarranty", filter.ProductWarranty),
                new DbParameter("prefecture", filter.Prefecture),
                new DbParameter("dateRegisteredMin", filter.DateRegistered.Min),
                new DbParameter("dateRegisteredMax", filter.DateRegistered.Max),
                new DbParameter("dateUpdatedMin", filter.DateUpdated.Min),
                new DbParameter("dateUpdatedMax", filter.DateUpdated.Max),
                new DbParameter("dateFirstPurchasedMin", filter.DateFirstPurchased.Min),
                new DbParameter("dateFirstPurchasedMax", filter.DateFirstPurchased.Max),
                new DbParameter("dateLastPurchasedMin", filter.DateLastPurchased.Min),
                new DbParameter("dateLastPurchasedMax", filter.DateLastPurchased.Max),
                new DbParameter("ecSubscriptionType", filter.EC_SubscriptionType),
                new DbParameter("ecEmailTarget", filter.EC_EmailTarget),
                new DbParameter("tvEmailAccept", filter.TV_EmailAccept),
                new DbParameter("extractPattern", filter.ExtractPattern),
                DbTools.StringToInts("shops", filter.Shops)
            };
        }

        private static object GetStartingIndex(int? page = 1)
        {
            return (page - 1) * 50;
        }

        private static object GetSexFilter(Sex[] selected)
        {
            if (selected == null || selected.Length != 1) return null;

            return selected[0];
        }
    }
}
