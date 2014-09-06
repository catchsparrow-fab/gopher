using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.Model.Domain;

namespace Gopher.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public UserListViewModel()
        {
            Users = new List<User>();
        }
    }
}