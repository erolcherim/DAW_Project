using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.CompanyRepository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByNameAsync(string name);
        Task<Company> GetCompanyByCEO(string ceo);
    }
}
