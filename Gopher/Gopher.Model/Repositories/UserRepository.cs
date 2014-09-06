using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Model.Tools;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gopher.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public string Add(User item)
        {
            var user = CreateInEntityFramework(item);
            if (item.IsAdmin)
                Helper.AddToRole(user.Id, "Admin");
            return user.Id;
        }

        public void Update(User item)
        {
            var userManager = GetUserManager();
            var user = ToEntityFramework(item);
            if (item.IsAdmin)
                userManager.AddToRole(user.Id, "Admin");
            userManager.Update(user);
        }

        public void Delete(string id)
        {
            var userManager = GetUserManager();
            var user = userManager.FindById(id);
            if (user != null)
                userManager.Delete(user);
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
                IsAdmin = user.Roles.Any(item => item.RoleId == Helper.AdminRoleId),
                Id = user.Id,
                Email = user.Email
            };
        }

        private static UserManager<ApplicationUser> GetUserManager()
        {
            return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        private static ApplicationUser ToEntityFramework(User user)
        {
            var applicationUser = GetUserManager().FindById(user.Id);
            applicationUser.UserName = user.Name;
            applicationUser.Email = user.Email;
            return applicationUser;
        }

        private static ApplicationUser CreateInEntityFramework(User user)
        {
            var applicationUser = new ApplicationUser() { UserName = user.Name, Email = user.Email };
            var result = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())).Create(applicationUser, DefaultPassword(user.Name));
            if (result.Succeeded)
                return applicationUser;
            throw new Exception();
        }

        private static string DefaultPassword(string userName)
        {
            return userName + "1234";
        }

        public IEnumerable<User> GetAll()
        {
            var collection = context.Users.ToList();
            return from user in collection
                   select FromEntityFramework(user);
        }
    }
}
