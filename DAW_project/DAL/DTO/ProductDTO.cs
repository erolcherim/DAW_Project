using DAW_Project.DAL.Models;

namespace DAW_Project.DAL.DTO
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public int? PricePerUnit { get; set; }
        public bool IsAvaiable { get; set; }

        public ProductDTO(Product product)
        {
            ProductName=product.ProductName;
            PricePerUnit=product.PricePerUnit;
            IsAvaiable = product.IsAvaiable;
        }
        public ProductDTO() { }
    }
}
