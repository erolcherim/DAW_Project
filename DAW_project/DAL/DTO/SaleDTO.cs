using DAW_Project.DAL.Models;

namespace DAW_Project.DAL.DTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int? Value { get; set; }
        public int? ProductQuantity { get; set; }

        public SaleDTO(Sale sale)
        {
            ProductId = sale.ProductId;
            UserId = sale.UserId;
            BranchId = sale.BranchId;
            Value = sale.Value;
            ProductQuantity = sale.ProductQuantity;
        }

        public SaleDTO() { }
    }
}
