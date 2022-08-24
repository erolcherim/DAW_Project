using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_project.DAL.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? PricePerUnit { get; set; }
        public bool IsAvaiable { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }
    }
}
