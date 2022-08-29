using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.SessionTokenRepository
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}