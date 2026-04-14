using Microsoft.AspNetCore.Identity;

namespace MySchoolApp.Web.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // --- ROLES ---
        string[] roles = { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // --- ADMIN USER ---
        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, "P@ssw0rd");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                throw new Exception("Failed to create admin user: " +
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
