using Microsoft.AspNetCore.Identity;

namespace DAW_Project.DAL.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
