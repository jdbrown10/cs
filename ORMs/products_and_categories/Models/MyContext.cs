using Microsoft.EntityFrameworkCore;
namespace products_and_categories.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories {get;set;}

        public DbSet<Product> Products {get;set;}

        public DbSet<ProductCategory> ProductCategories {get;set;}

    }
}