using DAW_Project.DAL;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<User>> GetAllUsersAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User> GetUserAndUserRoleById(int userId) =>
            await _context.Users.Include(user => user.UserRoles).ThenInclude(userRole => userRole.Role).FirstOrDefaultAsync(u => u.UserId.Equals(userId));

        public async Task<User> GetUserByEmail(string email) =>
            await _context.Users.Where(user => user.Email.Equals(email)).FirstOrDefaultAsync();
    }
}
