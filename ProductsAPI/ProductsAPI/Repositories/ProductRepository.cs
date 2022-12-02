using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Repositories
{
  public class IProductRepository
  {
    // Creating a constructor and injecting the ProductDbContext class into the repository:
    private readonly ProductDbContext _productDbContext;
    public IProductRepository(ProductDbContext productDbContext)
    {
      _productDbContext = productDbContext;
    }

    // Creating a method which returns the DbSet Products from the ProductDbContext class:
    public DbSet<Product> GetProducts()
    {
      return _productDbContext.Products;
    }

    public DbSet<Product> DeleteProduct(int id)
    {
      _productDbContext.Products.Remove(_productDbContext.Products.FirstOrDefault(a => a.ProductId == id));
      _productDbContext.SaveChanges();

      return _productDbContext.Products;


    }
  }
}
