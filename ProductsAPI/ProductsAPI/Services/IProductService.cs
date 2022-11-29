using Microsoft.AspNetCore.Mvc;
using ProductsData.Entities;

namespace ProductsAPI.Services
{
  public interface IProductService
  {
    Task<ActionResult<List<Product>>> GetProducts();
    Task<ActionResult<List<Product>>> CreateProduct(Product product);
    Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product);
    Task<ActionResult<List<Product>>> DeleteProduct(int id);
  }
}
