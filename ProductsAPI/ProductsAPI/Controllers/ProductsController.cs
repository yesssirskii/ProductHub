using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ProductsAPI.Repositories;
using ProductsAPI.Services;
using ProductsData.Entities;
using ProductsData.Models;
using System.Security.Permissions;

namespace ProductsAPI.Controllers
{
  public class ProductsController : Controller
  {
    private readonly ProductService _productService;
    private readonly ProductDbContext _context;

    // Injecting the service into the controller using DI:
    public ProductsController(ProductService productService, ProductDbContext context, IProductRepository repository) //constructor
    {
      _productService = productService;
      _context = context;
    }

    [HttpGet("getProducts")]
    public async Task<ActionResult<List<Product>>> getProducts()
    {
      return Ok(await _context.Products.ToListAsync());
    }

    [HttpPost("addProduct")]
    public async Task<ActionResult<List<Product>>> addProduct(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();

      return Ok(await _context.Products.ToListAsync());
    }

    [HttpPut("updateProduct")]
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

    [HttpDelete("deleteProduct")]
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
  // GET products method:
  [HttpGet("getProducts")]
  public IActionResult Get()
  {
    return Ok(_productService.getProducts());
  }

  // POST product method:
  [HttpPost("addProduct")]
  public ActionResult<List<Product>> Add(Product newProduct)
  {
    return Ok(_productService.createProduct(newProduct));
  }

  // PUT product method:
  [HttpPut("updateProduct")]
  public IActionResult Update(Product updatedProduct)
  {
    return Ok(_productService.updateProduct(updatedProduct));
  }

  // DELETE product method:
  [HttpDelete("deleteProduct")]
  public ActionResult<List<Product>> Delete(int id)
  {
    return Ok(_productService.deleteProduct(id));
  }*/
}
