using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAW_Project.DAL.Models
{
    [Table("Branch")]
    public class Branch
    {
        [Key]
        public int BrachId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchManager { get; set; } 
        public int NumberOfEmployees { get; set; } 
        public string? Location { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }

    }
}
