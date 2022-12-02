using Microsoft.AspNetCore.Mvc;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public interface IProductService
  {

    /*Task<ActionResult<List<Product>>> GetProducts();
    Task<ActionResult<List<Product>>> CreateProduct(Product product);
    Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product);
    Task<ActionResult<List<Product>>> DeleteProduct(int id);*/

    IEnumerable<GetProductsDTO> GetProducts();
    IEnumerable<Product> CreateProduct(CreateProductDTO createProductDto);
    IEnumerable<Product> UpdateProduct(int id, UpdateProductDTO updateProductDto);
    IEnumerable<DeleteProductDTO> DeleteProduct(int id);
  }
}
