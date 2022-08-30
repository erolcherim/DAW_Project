using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Project.DAL.Models
{
    [Table("Customer")]
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must have exactly 10 characters")]
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
