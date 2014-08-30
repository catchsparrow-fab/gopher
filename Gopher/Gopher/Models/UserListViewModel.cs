using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gopher.Models
{
    public class UserItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class UserListViewModel
    {
        public IEnumerable<UserItem> Users { get; set; }

        public UserListViewModel()
        {
            Users = new List<UserItem>();
        }
    }
}