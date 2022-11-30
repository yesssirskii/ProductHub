using System;
using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Repositories;
using ProductsData.Entities;
using Microsoft.AspNetCore.Http;
using ProductsData.Models;

namespace ProductsAPI.Services
{
  public class ProductService : IProductService
  {
    // Injecting the product repository and the ProductDTO class into the product service:
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(ProductDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper; 
    }

    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();

      return await _context.Products.ToListAsync();
    }
    public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
    {

      var dbProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

      dbProduct.Name = product.Name;
      dbProduct.Price = product.Price;
      dbProduct.Country = product.Country;
      dbProduct.ProductType = product.ProductType;

      await _context.SaveChangesAsync();

      return await _context.Products.ToListAsync();
    }

    public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
    {
      _context.Products.Remove(_context.Products.FirstOrDefault(a => a.ProductId == id));
      await _context.SaveChangesAsync();

      return await _context.Products.ToListAsync();
    }
  }
}

