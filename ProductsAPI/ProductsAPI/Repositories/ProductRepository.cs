using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductsData.Entities;

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
    public DbSet<Product> getProducts()
    {
      return _productDbContext.Products;
    }
  }
}
