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
        IAuthWrapperRepository AuthWrapper { get; }
        IBranchRepository Branch { get; }
        ICompanyRepository Company { get; }
        IProductRepository Product { get; }
        ISaleRepository Sale { get; }
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }
        int Save();
    }
}