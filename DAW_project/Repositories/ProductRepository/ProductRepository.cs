using DAW_project.DAL;
using DAW_project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Product>> GetAllProductsAsync() =>
            await _context.Products.ToListAsync();

        public async Task<List<Product>> GetAllProductsInStock(bool isAvailable) =>
            await _context.Products.Where(product => product.IsAvaiable.Equals(isAvailable)).ToListAsync();

        public async Task<List<Product>> GetAllProductsMoreExpensiveThan(int price) =>
            await _context.Products.Where(product => product.PricePerUnit > price).ToListAsync();

        public async Task<Product> GetProductByProductName(string productName) =>
            await _context.Products.Where(product => product.ProductName.Equals(productName)).FirstOrDefaultAsync();

    }
}
