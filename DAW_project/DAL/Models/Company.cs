using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Project.DAL.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CEO { get; set; }
        public string? CompanyLogo { get; set; }
        public ICollection<Branch>? Branches { get; set; }
        
    }
}
