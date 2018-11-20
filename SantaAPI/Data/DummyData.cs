using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantaAPI.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            //context.Database.EnsureCreated();

            string password = "P@$$w0rd";

            if (await userManager.FindByNameAsync("santa") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "santa",
                    Email = "santa@np.com",
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            if (await userManager.FindByNameAsync("tim") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "tim",
                    Email = "tim@np.com",

                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Child");
                }
            }
        }
    }
}
