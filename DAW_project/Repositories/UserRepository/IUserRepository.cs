using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAndUserRoleById(int userId);
        Task<User> GetUserByEmail(string email);
    }
}