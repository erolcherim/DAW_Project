using DAW_Project.Repositories.AuthWrapperRepository;
using DAW_Project.Repositories.BranchRepository;
using DAW_Project.Repositories.CompanyRepository;
using DAW_Project.Repositories.ProductRepository;
using DAW_Project.Repositories.SaleRepository;

namespace DAW_Project.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthWrapperRepository AuthWrapper { get; }
        IBranchRepository Branch { get; }
        ICompanyRepository Company { get; }
        IProductRepository Product { get; }
        ISaleRepository Sale { get; }
        int Save();
    }
}