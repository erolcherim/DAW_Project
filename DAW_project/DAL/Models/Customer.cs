using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_project.DAL.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must have exactly 10 characters")]
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }
    }
}
