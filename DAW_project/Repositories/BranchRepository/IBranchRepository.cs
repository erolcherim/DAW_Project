using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.BranchRepository
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<List<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchByBranchManager(string managerName);
        Task<List<Branch>> GetSmallBranches();
        Task<List<Branch>> GetBranchesByLocation(string location);
    }
}
