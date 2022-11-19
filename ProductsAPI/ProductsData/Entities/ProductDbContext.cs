using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
          new ProductType { id = 1, type = "Kitchen Utensils" },
          new ProductType { id = 2, type = "Transportation" },
          new ProductType { id = 3, type = "Jewlery" },
          new ProductType { id = 4, type = "Consumables" },
          new ProductType { id = 5, type = "Furniture" }
          );
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasData(
          new Product { productId = 1, name = "Spoon", price = 32, country = "COLOMBIA"},
          new Product { productId = 2, name = "Bycicle", price = 569, country = "CROATIA"},
          new Product { productId = 3, name = "Necklace", price = 1600, country = "ITALY"},
          new Product { productId = 4, name = "Water", price = 5, country = "FRANCE"},
          new Product { productId = 5, name = "Chair", price = 260, country = "ITALY"}
          );
      });
    }
  }
}

