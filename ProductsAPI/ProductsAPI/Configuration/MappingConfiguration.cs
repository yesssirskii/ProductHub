using AutoMapper;
using ProductsAPI.Repositories;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Configuration
{
  public class MappingConfiguration : Profile
  {
    public MappingConfiguration()
    {
      // Defining a profile to convert from Product to productDTO:
      CreateMap<Product, ProductDTO>();
      CreateMap<ProductDTO, Product>();
    }
  }
}
