using DAW_Project.DAL;
using DAW_Project.Repositories.SessionTokenRepository;
using DAW_Project.Repositories.UserRepository;

namespace DAW_Project.Repositories.AuthWrapperRepository
{
    public class AuthWrapperRepository : IAuthWrapperRepository
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;

        public AuthWrapperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository.UserRepository(_context); //Double check
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository.SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
