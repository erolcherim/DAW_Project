using DAW_Project.DAL.DTO;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsInStock(bool isAvailable);
        Task<List<Product>> GetAllProductsMoreExpensiveThan(int price);
        Task<Product> GetProductByProductName(string productName);
        Task<List<ProductDTO>> GetAllProductsByValueDescending();

    }
}
