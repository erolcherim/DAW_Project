using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Project.DAL.Models
{
    [Table("Sale")]
    public class Sale
    {
        [Key, Column(Order = 1)]
        public int BranchId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        [Key, Column(Order = 3)]
        public int UserId { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int? value { get; set; }
    }
}
