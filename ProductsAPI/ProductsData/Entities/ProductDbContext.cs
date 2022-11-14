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

    // Defining relationships between database entities:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<ProductType>(entity =>
      {
        entity.HasData(
          new ProductType { Id = 1, Type = "Kitchen Utensils" },
          new ProductType { Id = 2, Type = "Transportation" },
          new ProductType { Id = 3, Type = "Jewlery" },
          new ProductType { Id = 4, Type = "Consumables" },
          new ProductType { Id = 5, Type = "Furniture" }
          );
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasData(
          new Product { ProductId = 1, Name = "Spoon", Price = 32, Country = "COLOMBIA" },
          new Product { ProductId = 2, Name = "Bycicle", Price = 569, Country = "CROATIA" },
          new Product { ProductId = 3, Name = "Necklace", Price = 1600, Country = "ITALY" },
          new Product { ProductId = 4, Name = "Water", Price = 5, Country = "FRANCE" },
          new Product { ProductId = 5, Name = "Chair", Price = 260, Country = "ITALY" }
          );
      });
    }
  }
}

