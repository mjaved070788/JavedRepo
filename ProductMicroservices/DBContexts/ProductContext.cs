using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Models;
namespace ProductMicroservices.DBContexts
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories {Id = 1,CategoryName = "Laptop",Description = "DELL XPS 13"},
                new Categories {Id = 2,CategoryName = "Desktop",Description = "DELL"},
                new Categories {Id = 3,CategoryName = "Tablet",Description = "OnePlus One"},
                new Categories {Id = 4,CategoryName = "Mobile",Description = "iPhone 16"},
                new Categories { Id = 5, CategoryName = "Plamtop", Description = "Motorola" }
            ); 
        }

    }
}
