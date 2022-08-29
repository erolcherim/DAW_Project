using DAW_Project.DAL;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Repositories.SaleRepository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Sale>> GetAllSalesAsync() =>
            await _context.Sales.ToListAsync();

        public async Task<List<Sale>> GetAllSalesWithValueHigherThan(int value) =>
            await _context.Sales.Where(sale => sale.value > value).ToListAsync();

        public async Task<List<Sale>> GetAllSalesDoneByUser(int userId) =>
            await _context.Sales.Where(sale => sale.UserId.Equals(userId)).ToListAsync();

        public async Task<List<Sale>> GetAllSalesThatContainProduct(int productId) =>
            await _context.Sales.Where(sale => sale.ProductId.Equals(productId)).ToListAsync();

    }
}
