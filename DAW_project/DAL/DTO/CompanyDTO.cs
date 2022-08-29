using DAW_Project.DAL.Models;

namespace DAW_Project.DAL.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CEO { get; set; }
        public string? CompanyLogo { get; set; }

        public CompanyDTO(Company company)
        {
            CompanyId = company.CompanyId;
            CompanyName = company.CompanyName;
            CEO = company.CEO;
            CompanyLogo = company.CompanyLogo;  
        }
        public CompanyDTO() { }
    }
}
