using DAW_Project.DAL.DTO;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {

            if (_unitOfWork.Products == null)
            {
                return NotFound();
            }
            var results = (await _unitOfWork.Products.GetAll()).Select(a => new ProductDTO(a)).ToList();
            return results;
        }

        //GET: api/Products/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var result = await _unitOfWork.Products.GetById(id);

            if (result == null)
            {
                return NotFound("Product with specified id doesn't exist");
            }

            return new ProductDTO(result);
        }

        [HttpGet("get-products-descending")]
        public async Task<IActionResult> GetProductsByValueDescending()
        {
            var result = await _unitOfWork.Products.GetAllProductsByValueDescending();

            if (result == null)
            {
                return NotFound("There are no products in the current context");
            }
            return Ok(result);
        }

        //PUT: api/Products/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            var productInDb = await _unitOfWork.Products.GetById(id);

            if (productInDb == null)
            {
                return NotFound("Product with specified id doesn't exist");
            }

            productInDb.ProductName = product.ProductName;
            productInDb.PricePerUnit = product.PricePerUnit;
            productInDb.IsAvaiable = product.IsAvaiable;

            await _unitOfWork.Products.Update(productInDb);
            _unitOfWork.Save();

            return Ok();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProducts(ProductDTO product)
        {
            var productToAdd = new Product();
            productToAdd.ProductName = product.ProductName;
            productToAdd.PricePerUnit = product.PricePerUnit;
            productToAdd.IsAvaiable = product.IsAvaiable;

            await _unitOfWork.Products.Create(productToAdd);
            _unitOfWork.Save();

            return Ok();
        }


        // Delete: api/Products/id
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productInDb = await _unitOfWork.Products.GetById(id);

            if (productInDb == null)
            {
                return NotFound("Product with specified id doesn't exist");
            }

            await _unitOfWork.Products.Delete(productInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }

}