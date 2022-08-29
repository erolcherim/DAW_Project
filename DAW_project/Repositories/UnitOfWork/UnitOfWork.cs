using DAW_Project.DAL;
using DAW_Project.Repositories.AuthWrapperRepository;
using DAW_Project.Repositories.BranchRepository;
using DAW_Project.Repositories.CompanyRepository;
using DAW_Project.Repositories.ProductRepository;
using DAW_Project.Repositories.SaleRepository;
using DAW_Project.Repositories.SessionTokenRepository;
using DAW_Project.Repositories.UserRepository;

namespace DAW_Project.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AuthWrappers = new AuthWrapperRepository.AuthWrapperRepository(_context); //not used = useless, maybe modify
            Branches = new BranchRepository.BranchRepository(_context);
            Companies = new CompanyRepository.CompanyRepository(_context);
            Products = new ProductRepository.ProductRepository(_context);
            Sales = new SaleRepository.SaleRepository(_context);
            Users = new UserRepository.UserRepository(_context);
            SessionTokens = new SessionTokenRepository.SessionTokenRepository(_context);
        }

        public IAuthWrapperRepository AuthWrappers
        {
            get;
            private set;
        }

        public IBranchRepository Branches
        {
            get;
            private set;
        }

        public ICompanyRepository Companies
        {
            get;
            private set;
        }

        public IProductRepository Products
        {
            get;
            private set;
        }

        public ISaleRepository Sales
        {
            get;
            private set;
        }

        public IUserRepository Users
        {
            get;
            private set;
        }

        public ISessionTokenRepository SessionTokens
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
