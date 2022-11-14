using System;
using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Repositories;
using ProductsData.Entities;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public class ProductService
  {
    // Injecting the product repository and the ProductDTO class into the product service:
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // Method which returns IEnumerable<ProductDTO>:
    public List<ProductDTO> GetProducts()
    {
      var products = _repository.GetProducts().ToList();
      return _mapper.Map<List<ProductDTO>>(products);
    }
  }
}
