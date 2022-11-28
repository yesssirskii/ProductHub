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
  public class ProductService : ControllerBase
  {
    // Injecting the product repository and the ProductDTO class into the product service:
    private readonly ProductDbContext _context;

    public ProductService(ProductDbContext context)
    {
      _context = context;
    }

    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      return Ok(await _context.Products.ToListAsync());
    }

    public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }
    public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
    {

      var dbProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

      if (dbProduct != null)
      {
        dbProduct.Name = product.Name;
        dbProduct.Price = product.Price;
        dbProduct.Country = product.Country;
        dbProduct.ProductType = product.ProductType;

        await _context.SaveChangesAsync();

        return Ok(await _context.Products.ToListAsync());
      }

      return NotFound("Product not found.");
    }

    public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
    {
      _context.Products.Remove(_context.Products.FirstOrDefault(a => a.ProductId == id));
      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }
  }
}

