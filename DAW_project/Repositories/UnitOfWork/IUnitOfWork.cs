using DAW_Project.Repositories.AuthWrapperRepository;
using DAW_Project.Repositories.BranchRepository;
using DAW_Project.Repositories.CompanyRepository;
using DAW_Project.Repositories.ProductRepository;
using DAW_Project.Repositories.SaleRepository;
using DAW_Project.Repositories.SessionTokenRepository;
using DAW_Project.Repositories.UserRepository;

namespace DAW_Project.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthWrapperRepository AuthWrappers { get; }
        IBranchRepository Branches { get; }
        ICompanyRepository Companies { get; }
        IProductRepository Products { get; }
        ISaleRepository Sales { get; }
        IUserRepository Users { get; }
        ISessionTokenRepository SessionTokens { get; }
        int Save();
    }
}