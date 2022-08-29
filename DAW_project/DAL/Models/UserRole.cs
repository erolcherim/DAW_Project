using Microsoft.AspNetCore.Identity;

namespace DAW_Project.DAL.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
