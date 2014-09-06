using Gopher.Model.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gopher.Model.Tools
{
    public class Helper
    {
        public static void AddToRole(string userId, string roleName)
        {
            var context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(userId, "Admin");
        }

        public static string AdminRoleId
        {
            get
            {
                return "56470308-4e48-40fb-88d5-b7f617386496";
            }
        }
    }
}