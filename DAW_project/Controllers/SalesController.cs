using DAW_Project.DAL.DTO;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.UnitOfWork;
using DAW_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleService _service;

        public SalesController(IUnitOfWork unitOfWork, ISaleService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        //POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<SaleDTO>> PostSale(SaleDTO sale)
        {
            var saleToAdd = new Sale();

            saleToAdd.UserId = sale.UserId;
            saleToAdd.BranchId = sale.BranchId;
            saleToAdd.ProductId = sale.ProductId;
            saleToAdd.ProductQuantity = sale.ProductQuantity;
            //saleToAdd.Value = await _service.CalculateSaleValue(sale.ProductId);
            saleToAdd.Value = sale.Value;
            

            await _unitOfWork.Sales.Create(saleToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        //GET: api/Sales
        [HttpGet]
        public async Task<ActionResult> GetAllSales()
        {
            var sales = await _unitOfWork.Sales.GetAllSalesAsync();
            if (sales == null)
            {
                return NotFound("There are currently no sales in the DB");
            }
            return Ok(sales);
        }
    }
}
