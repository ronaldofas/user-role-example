using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserAccessControl.Data;
using UserAccessControl.Models;

public class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();

        // Criação das roles
        var roles = new[] { "Admin", "User", "EspecialUser" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        await CriarUsuarioAdmin(userManager);
        await CriarUsuarioComun(userManager);
        await CriarUsuarioEspecial(userManager);

        
    }

    private static async Task CriarUsuarioAdmin(UserManager<ApplicationUser> userManager)
    {
        // Criação de um usuário admin
        var adminUser = new ApplicationUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            FullName = "Administrator"
        };

        if (userManager.Users.All(u => u.Id != adminUser.Id))
        {
            var result = await userManager.CreateAsync(adminUser, "Password123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");

                // Ativa o email
                ApplicationUser admin = await userManager.FindByNameAsync("admin@example.com") ?? new ApplicationUser();
                admin.EmailConfirmed = true;
                await userManager.UpdateAsync(admin);
            }
        }
    }

    private static async Task CriarUsuarioComun(UserManager<ApplicationUser> userManager)
    {
        // Criação de um usuário admin
        var usuarioComum = new ApplicationUser
        {
            UserName = "user@example.com",
            Email = "user@example.com",
            FullName = "User"
        };

        if (userManager.Users.All(u => u.Id != usuarioComum.Id))
        {
            var result = await userManager.CreateAsync(usuarioComum, "Senha123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(usuarioComum, "User");

                // Ativa o email
                ApplicationUser user = await userManager.FindByNameAsync("user@example.com") ?? new ApplicationUser();
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
            }
        }
    }

    private static async Task CriarUsuarioEspecial(UserManager<ApplicationUser> userManager)
    {
        // Criação de um usuário admin
        var usuarioEspecial = new ApplicationUser
        {
            UserName = "especial_user@example.com",
            Email = "especial_user@example.com",
            FullName = "Especial User"
        };

        if (userManager.Users.All(u => u.Id != usuarioEspecial.Id))
        {
            var result = await userManager.CreateAsync(usuarioEspecial, "Senha123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(usuarioEspecial, "EspecialUser");

                // Ativa o email
                ApplicationUser user = await userManager.FindByNameAsync("especial_user@example.com") ?? new ApplicationUser();
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
            }
        }
    }
}

