using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsAPI.Repositories;
using ProductsAPI.Services;
using ProductsData.Entities;
using System.Security.Permissions;

namespace ProductsAPI.Controllers
{
  public class ProductsController : Controller
  {
    private readonly ProductDbContext _context;
    public ProductService _productService;

    // Injecting the DbContext and the product repository into the controller:
    public ProductsController(ProductDbContext context, ProductService productService) //constructor
    {
     this._context = context;
      _productService = productService;
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
      return Ok(_productService.GetProducts());
    }

    [HttpPost("AddProducts")]
    public Product AddProducts(Product product)
    {
      _context.Products.Add(product);
      bool isSaved = _context.SaveChanges() > 0;
      if (isSaved)
      {
        return product;
      }
      return null;
    }

    [HttpPut("EditProducts")]
    public void EditProducts(int id, [FromBody] Product product)
    {
      var productDetail = _context.Products.FirstOrDefault(x => x.ProductId == id);
      if(productDetail != null)
      {
        productDetail.Name = product.Name;
        productDetail.Price = product.Price;
        productDetail.Country = product.Country;

        _context.SaveChanges();
      }
    }

    [HttpDelete("DeleteProducts")]
    public void Deleteproducts(int id)
    {
      _context.Products.Remove(_context.Products.FirstOrDefault(e => e.ProductId == id));
      _context.SaveChanges();
    }
  }
}
