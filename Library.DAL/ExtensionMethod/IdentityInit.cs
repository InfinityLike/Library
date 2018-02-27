using Library.Entities.Enums;
using Library.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Library.DAL
{
    public static class IdentityInit
    {
        public async static Task InitializeAsync(this LibraryDb libraryDb, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "admin";
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            string roleAdmin = Roles.Admin.ToString().ToLower();
            string roleUser = Roles.User.ToString().ToLower();
            if (await roleManager.FindByNameAsync(roleAdmin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleAdmin));
            }
            if (await roleManager.FindByNameAsync(roleUser) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleUser));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User();
                admin.Name = adminName;
                admin.Email = adminEmail;
                admin.UserName = adminEmail;
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, roleAdmin);
                }
            }
        }
    }
}
