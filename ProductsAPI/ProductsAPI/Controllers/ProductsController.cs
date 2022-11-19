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
    private readonly ProductDbContext _context;
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper; 

    // Injecting the service into the controller:
    public ProductsController(ProductService productService, ProductDbContext context, IProductRepository repository, IMapper mapper) //constructor
    {
      _productService = productService;
      _context = context;
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("getProducts")]
    public IActionResult Get()
    {
      return Ok(_productService.getProducts());
    }

    [HttpPost("addProduct")]
    public ActionResult<List<ProductDTO>> Add(ProductDTO newProduct)
    {
      return Ok(_productService.addProduct(newProduct));
    }

    [HttpPut("updateProduct")]
    public IActionResult Update(int id, ProductDTO updatedProduct)
    {
      return Ok(_productService.updateProduct(id, updatedProduct));
    }

    [HttpDelete("deleteProduct")]
    public ActionResult<List<Product>> Delete(int id)
    {
      return Ok(_productService.deleteProduct(id));
    }
  }
}
