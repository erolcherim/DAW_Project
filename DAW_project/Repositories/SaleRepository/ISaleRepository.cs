using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.SaleRepository
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<List<Sale>> GetAllSalesAsync();
        Task<List<Sale>> GetAllSalesDoneByUser(int userId);
        Task<List<Sale>> GetAllSalesThatContainProduct(int productId);
        Task<List<Sale>> GetAllSalesWithValueHigherThan(int value);
    }
}