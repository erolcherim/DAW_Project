using DAW_project.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW_project.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Branch>? Branches { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Customer>? Customers { get; set; } 
        public DbSet<Product>? Products { get; set; }
        public DbSet<Sale>? Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Company has multiple Branches (1:m)
            modelBuilder.Entity<Company>()
                .HasMany(company => company.Branches)
                .WithOne(branch => branch.Company);

            //Multiple Customers buy multiple Producst from multiple Branches (m:m:m)
            modelBuilder.Entity<Sale>()
                .HasKey(sale =>
                    new
                    {
                        sale.BranchId,
                        sale.CustomerId,
                        sale.ProductId
                    });

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Branch)
                .WithMany(branch => branch.Sales);

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Customer)
                .WithMany(customer => customer.Sales);

            modelBuilder.Entity<Sale>()
                .HasOne(sale => sale.Product)
                .WithMany(product => product.Sales);
            //Customer is User (1:1) TODO later
            
            base.OnModelCreating(modelBuilder);
        }
          
    }
}
