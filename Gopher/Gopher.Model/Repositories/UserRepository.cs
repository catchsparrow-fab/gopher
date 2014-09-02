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

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User GetSingle(string id)
        {
            var user = context.Users.SingleOrDefault(i => i.Id == id);
            if (user == null) return null;

            return FromEntityFramework(user);
        }

        private static User FromEntityFramework(ApplicationUser user)
        {
            return new User()
            {
                Name = user.UserName,
                IsAdmin = user.Roles.Any(item => item.Role.Name.ToLower() == "admin"),
                Id = user.Id
            };
        }

        public IEnumerable<User> GetAll()
        {
            var collection = context.Users.ToList();
            return from user in collection
                   select FromEntityFramework(user);
        }
    }
}
