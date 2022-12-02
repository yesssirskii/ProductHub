using AutoMapper;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Configuration
{
  public class MappingConfiguration : Profile
  {
    public MappingConfiguration()
    {
      CreateMap<Product, GetProductsDTO>();
      CreateMap<CreateProductDTO, Product>();
      CreateMap<UpdateProductDTO, Product>();
      CreateMap<DeleteProductDTO, Product>();
      CreateMap<Product, DeleteProductDTO>();
    }
  }
}
