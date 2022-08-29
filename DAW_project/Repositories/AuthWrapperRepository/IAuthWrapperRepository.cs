using DAW_Project.Repositories.SessionTokenRepository;
using DAW_Project.Repositories.UserRepository;

namespace DAW_Project.Repositories.AuthWrapperRepository
{
    public interface IAuthWrapperRepository
    {
        ISessionTokenRepository SessionToken { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}