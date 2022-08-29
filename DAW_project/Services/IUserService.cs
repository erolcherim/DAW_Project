using DAW_Project.DAL.DTO;

namespace DAW_Project.Services
{
    public interface IUserService
    {
        Task<string> LoginUser(UserLoginDTO dto);
        Task<bool> RegisterUserAsync(UserRegisterDTO dto);
    }
}