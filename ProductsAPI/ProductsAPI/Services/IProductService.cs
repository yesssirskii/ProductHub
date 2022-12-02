using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public interface IProductService
  {
    IEnumerable<GetProductsDTO> GetProducts();
    IEnumerable<Product> CreateProduct(CreateProductDTO createProductDto);
    IEnumerable<Product> UpdateProduct(int id, UpdateProductDTO updateProductDto);
    IEnumerable<DeleteProductDTO> DeleteProduct(int id);
  }
}
