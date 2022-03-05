using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    internal sealed class AppDatabaseContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Database/ApplicationDatabase.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int length = 4;
            Products[] products = new Products[length];

            for (int i = 1; i <= length; i++)
            {
                products[i - 1] = new Products
                {
                    ProductId = i,
                    ProductName = $"Product number {i}", 
                    ProductExpirationDate = new DateTime(2022,i,04),
                    ProductDescription = $"This is product {i} and it has some very interesting properties.",
                    ProductPrice = i,
                    ProductQuantity = i+20
                };
            }

            modelBuilder.Entity<Products>().HasData(products);
        }
    }
}
