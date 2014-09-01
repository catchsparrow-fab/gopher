using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Microsoft.AspNet.Identity;

namespace Gopher.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public int Add(User item)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return from user in context.Users
                   select new User()
                   {
                       Name = user.UserName
                   };
        }
    }
}
