using Microsoft.EntityFrameworkCore;

namespace ProductsData.Entities
{
  public class ProductDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    // Creating a constructor and making it inherit the base properties using the base() syntax:
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<ProductType>(entity =>
      {
        entity.HasData(
          new ProductType { Id = 1, Type = "Kitchen Utensils"},
          new ProductType { Id = 2, Type = "Transportation"},
          new ProductType { Id = 3, Type = "Jewlery"},
          new ProductType { Id = 4, Type = "Consumables"},
          new ProductType { Id = 5, Type = "Furniture"}
          );
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasData(
          new Product { ProductId = 1, Name = "Spoon", Price = 9.99, Country = "COLOMBIA", Type = "Kitchen Utensils"},
          new Product { ProductId = 2, Name = "Bycicle", Price = 4.999, Country = "CROATIA", Type = "Transportation"},
          new Product { ProductId = 3, Name = "Necklace", Price = 700.00, Country = "ITALY", Type = "Jewlery"},
          new Product { ProductId = 4, Name = "Water", Price = 3.99, Country = "FRANCE", Type = "Consumables"},
          new Product { ProductId = 5, Name = "Chair", Price = 350.00, Country = "ITALY", Type = "Furniture"}
          );
      });
    }
  }
}

