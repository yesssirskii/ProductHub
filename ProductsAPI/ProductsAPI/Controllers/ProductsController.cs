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
using System.Data.Entity;
using System.Security.Permissions;

namespace ProductsAPI.Controllers
{
  public class ProductsController : Controller
  {
    private readonly ProductService _productService;

    // Injecting the service into the controller using DI:
    public ProductsController(ProductService productService, ProductDbContext context, IProductRepository repository, IMapper mapper) //constructor
    {
      _productService = productService;
    }

    // GET products method:
    [HttpGet("getProducts")]
    public IActionResult Get()
    {
      return Ok(_productService.getProducts());
    }

    // POST product method:
    [HttpPost("addProduct")]
    public ActionResult<List<ProductDTO>> Add(ProductDTO newProduct)
    {
      return Ok(_productService.addProduct(newProduct));
    }

    // PUT product method:
    [HttpPut("updateProduct")]
    public IActionResult Update(int id, ProductDTO updatedProduct)
    {
      return Ok(_productService.updateProduct(id, updatedProduct));
    }

    // DELETE product method:
    [HttpDelete("deleteProduct")]
    public ActionResult<List<Product>> Delete(int id)
    {
      return Ok(_productService.deleteProduct(id));
    }
  }
}
