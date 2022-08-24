using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_project.DAL.Models
{
    [Table("Sale")]
    public class Sale
    {
        [Key, Column(Order = 1)]
        public int BranchId { get; set; }
        [Key, Column(Order = 2)]
        public int CompanyId { get; set; }
        [Key, Column(Order = 3)]
        public int CustomerId { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
