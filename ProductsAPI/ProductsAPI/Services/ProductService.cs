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
  public class ProductService: ControllerBase
  {
    // Injecting the product repository and the ProductDTO class into the product service:
    private readonly IProductRepository _repository;
    private readonly ProductDbContext _context;

    public ProductService(IProductRepository repository, IMapper mapper, ProductDbContext context)
    {
      _repository = repository;
      _context = context;
    }

    public async Task<ActionResult<List<Product>>> getProducts()
    {
      return Ok(await _context.Products.ToListAsync());
    }

    public async Task<ActionResult<List<Product>>> addProduct(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }

    public async Task<ActionResult<List<Product>>> updateProduct(Product product)
    {
      var dbProduct = await _context.Products.FindAsync(product.productId);
      if (dbProduct == null)
        return BadRequest("Product not found.");

      dbProduct.name = product.name;
      dbProduct.price = product.price;
      dbProduct.country = product.country;

      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }

    public async Task<ActionResult<List<Product>>> deleteProduct(int id)
    {
      var dbProduct = await _context.Products.FindAsync(id);
      if (dbProduct == null)
        return BadRequest("Product not found.");

      _context.Products.Remove(dbProduct);
      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }
  }

  /*
  // GET method:
  public ActionResult<List<Product>> getProducts()
  {
    return Ok(_context.Products.Select(product => _mapper.Map<ProductDTO>(product)));
  }

  // POST method:
  public ActionResult<List<Product>> addProduct(ProductDTO newProduct)
  {
    var product = _mapper.Map<Product>(newProduct);
    _context.Products.Add(product);

    return Ok(_context.Products.Select(product => _mapper.Map<ProductDTO>(product)));
  }

  // PUT method:
  public ActionResult<List<Product>> updateProduct(int id, ProductDTO productDto)
  {
    var product = _repository.getProductById(id);
    _mapper.Map(productDto, product);

    return Ok(_mapper.Map<ProductDTO>(product));
  }

  // DELETE method:
  public ActionResult<List<Product>> deleteProduct(int id)
  {
    var product = _repository.getProductById(id);
    _context.Products.Remove(product);

    return Ok(_context.Products.Select(product => _mapper.Map<ProductDTO>(product)));
  }
  */
}

