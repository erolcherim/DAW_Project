using DAW_Project.DAL.Models;

namespace DAW_Project.DAL.DTO
{
    public class BranchDTO
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchManager { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string? Location { get; set; }
        public int CompanyId { get; set; }

        public BranchDTO(Branch branch)
        {
            BranchId = branch.BranchId;
            BranchName = branch.BranchName;
            BranchManager = branch.BranchManager;
            NumberOfEmployees = branch.NumberOfEmployees;
            Location = branch.Location;
            CompanyId = branch.CompanyId;
        }
        public BranchDTO() { }
    }
}
