using DAW_Project.DAL.Models;
using DAW_Project.Repositories.SaleRepository;
using DAW_Project.Repositories.UnitOfWork;

namespace DAW_Project.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> CalculateSaleValue(int id)
        {
            var s = (await _unitOfWork.Sales.GetById(id));
            return s.Product.PricePerUnit * s.ProductQuantity;
        }

    }
}
