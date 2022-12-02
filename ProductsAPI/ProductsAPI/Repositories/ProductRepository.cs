using Microsoft.EntityFrameworkCore;
using ProductsData.Entities;

namespace ProductsAPI.Repositories
{
  public class IProductRepository
  {
    private readonly ProductDbContext _productDbContext;
    public IProductRepository(ProductDbContext productDbContext)
    {
      _productDbContext = productDbContext;
    }

    // The functions below are used in the service (repository pattern; repository -> service -> controller):
    public DbSet<Product> GetProducts()
    {
      return _productDbContext.Products;
    }

    public DbSet<ProductType> GetProductTypes()
    {
      return _productDbContext.ProductTypes;  
    }

    public DbSet<Product> DeleteProduct(int id)
    {
      _productDbContext.Products.Remove(_productDbContext.Products.FirstOrDefault(a => a.ProductId == id));
      _productDbContext.SaveChanges();

      return _productDbContext.Products;
    }
  }
}
