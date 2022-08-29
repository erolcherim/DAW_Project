using DAW_Project.DAL;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Repositories.CompanyRepository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Company>> GetAllCompaniesAsync() =>
            await _context.Companies.ToListAsync();

        public async Task<Company> GetCompanyByNameAsync(string name) =>
            await _context.Companies.Where(c => c.CompanyName.Equals(name)).FirstOrDefaultAsync();

        public async Task<Company> GetCompanyByCEO(string ceo) =>
            await _context.Companies.Where(c => c.CEO.Equals(ceo)).FirstOrDefaultAsync();

    }
}
