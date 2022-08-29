using DAW_Project.DAL.Models;
using DAW_Project.DAL.Models.Constants;
using Microsoft.AspNetCore.Identity;

namespace DAW_Project.DAL.Seeders
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbContext _context;
        public InitialSeed(RoleManager<Role> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        public async Task SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            string[] roleNames =
{
                UserRoleType.Admin,
                UserRoleType.User
            };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    var roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = roleName
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}