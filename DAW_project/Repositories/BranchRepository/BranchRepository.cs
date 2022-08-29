using DAW_Project.DAL;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Repositories.BranchRepository
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository   
    {
        public BranchRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Branch>> GetAllBranchesAsync() =>
            await _context.Branches.ToListAsync();

        public async Task<Branch> GetBranchByBranchManager(string managerName) =>
            await _context.Branches.Where(branch => branch.BranchManager.Equals(managerName)).FirstOrDefaultAsync();

        //Small Branch = Branch with less than 20 employees
        public async Task<List<Branch>> GetSmallBranches() =>
            await _context.Branches.Where(branch => branch.NumberOfEmployees < 20).ToListAsync();

        public async Task<List<Branch>> GetBranchesByLocation(string location) =>
            await _context.Branches.Where(branch => branch.Location.Equals(location)).ToListAsync();


    }
}
