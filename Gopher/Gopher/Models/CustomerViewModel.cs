using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.ImportExport.Domain;
using Gopher.Model.Tools;

namespace Gopher.Models
{
    public class CustomerViewModel
    {
        public string Shop
        {
            get
            {
                return customer.ShopId;
            }
        }

        public string CustomerId
        {
            get
            {
                return customer.Id;
            }
        }

        public string Prefecture
        {
            get
            {
                return customer.Prefecture;
            }
        }

        public string NameKanji
        {
            get
            {
                return customer.NameKanji;
            }
        }
        public string NameKana
        {
            get
            {
                return customer.NameKana;
            }
        }

        public string Sex
        {
            get
            {
                if (customer.Sex != null)
                {
                    switch (customer.Sex)
                    {
                        case ImportExport.Domain.Sex.Male:
                            return "男性";
                            //return TranslationHelper.Get("Generic_Male");
                        case ImportExport.Domain.Sex.Female:
                            return "女性";
                            //return TranslationHelper.Get("Generic_Female");
                    }
                }

                return string.Empty;
            }
        }
        public string Phone
        {
            get
            {
                return customer.Phone; 
            }
        }
        public string Email
        {
            get
            {
                return customer.Email;
            }
        }

        private Customer customer;

        public CustomerViewModel(Customer customer)
        {
            this.customer = customer;
        }
    }
}