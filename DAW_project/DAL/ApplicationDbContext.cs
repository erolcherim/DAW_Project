using DAW_Project.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Branch>? Branches { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<User>? Users { get; set; } 
        public DbSet<Product>? Products { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SessionToken>? SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Company has multiple Branches (1:m)
            modelBuilder.Entity<Company>()
                .HasMany(company => company.Branches)
                .WithOne(branch => branch.Company);

            //Multiple Customers buy multiple Producst from multiple Branches (m:m:m)
            //modelBuilder.Entity<Sale>()
            //    .HasKey(sale =>
            //        new
            //        {
            //            sale.BranchId,
            //            sale.UserId,
            //            sale.ProductId
            //        });

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Branch)
                .WithMany(branch => branch.Sales);

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.User)
                .WithMany(user => user.Sales);

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Product)
                .WithMany(product => product.Sales);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });

        }
          
    }
}
