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
            AuthWrapper = new AuthWrapperRepository.AuthWrapperRepository(_context); //not used = useless, maybe modify
            Branch = new BranchRepository.BranchRepository(_context);
            Company = new CompanyRepository.CompanyRepository(_context);
            Product = new ProductRepository.ProductRepository(_context);
            Sale = new SaleRepository.SaleRepository(_context);
            User = new UserRepository.UserRepository(_context);
            SessionToken = new SessionTokenRepository.SessionTokenRepository(_context);
        }

        public IAuthWrapperRepository AuthWrapper
        {
            get;
            private set;
        }

        public IBranchRepository Branch
        {
            get;
            private set;
        }

        public ICompanyRepository Company
        {
            get;
            private set;
        }

        public IProductRepository Product
        {
            get;
            private set;
        }

        public ISaleRepository Sale
        {
            get;
            private set;
        }

        public IUserRepository User
        {
            get;
            private set;
        }

        public ISessionTokenRepository SessionToken
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
