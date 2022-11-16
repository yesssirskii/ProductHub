using System;
using System.Collections;
using System.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
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
    private readonly ProductDbContext _context;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // Method which returns IEnumerable<ProductDTO>:
    [HttpGet]
    public List<ProductDTO> Get()
    {
      var products = _repository.getProducts().ToList();
      return _mapper.Map<List<ProductDTO>>(products);
    }

    // POST method:
    [HttpPost]
    public Product Add(Product product)
    {
      _context.Products.Add(product);
      bool isSaved = _context.SaveChanges() > 0;
      if (isSaved)
      {
        return product;
      }
      return null;
    }

    // PUT method:
    [HttpPut]

    public void Edit(int id, [FromBody] Product product)
    {
      var productDetail = _context.Products.FirstOrDefault(x => x.productId == id);
      if (productDetail != null)
      {
        productDetail.name = product.name;
        productDetail.price = product.price;
        productDetail.country = product.country;

        _context.SaveChanges();
      }
    }

    // DELETE method:
    [HttpDelete]
    public void Delete(int id)
    {
      _context.Products.Remove(_context.Products.FirstOrDefault(e => e.productId == id));
      _context.SaveChanges();
    }

  }
}
