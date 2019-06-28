using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MishMashExamASP.NET.Middlewares
{
    public class RoleSeeder
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("User").Result)
            {
                var role = new IdentityRole { Name = "User" };
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).GetAwaiter().GetResult();
            }

            if (!roleManager.RoleExistsAsync
                ("Admin").Result)
            {
                var role = new IdentityRole { Name = "Admin" };
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).GetAwaiter().GetResult();
            }
        }
    }
}
