using GoodWillStones.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodWillStones.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // default , we are using it to seed data  
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { lCategory_ID = 1, sDescription = "Brick", sDisplayOrder = 1 },
                new Category { lCategory_ID = 2, sDescription = "M-Sand", sDisplayOrder = 2 },
                new Category { lCategory_ID = 3, sDescription = "P-Sand", sDisplayOrder = 3 },
                new Category { lCategory_ID = 4, sDescription = "Blue-Metal", sDisplayOrder = 4 });
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Product_ID = 1,
                    sProductName = "M-sand",
                    sDescription = "It is a type of sand ",
                    ListPrice = 100,
                    Price = 95,
                    Price50 = 90,
                    ListPrice100 = 80,
                    CategoryId = 2,
                    ImageURL = ""
                }
                );
        }
    }
}
