using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ProductsAPI.Repositories;
using ProductsAPI.Services;
using ProductsData.Entities;
using ProductsData.Models;
using System.Data;
using System.Security.Permissions;

namespace ProductsAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductService _productService;

    // Injecting the service into the controller using DI:
    public ProductsController(ProductService productService)
    {
      _productService = productService;
    }

    // GET products method:
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
      return await _productService.GetProducts();
    }

    // POST product method:
    [HttpPost]
    public async Task<ActionResult<List<Product>>> Create(Product product)
    {
      return await _productService.CreateProduct(product);
    }

    // PUT method:
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<List<Product>>> Update([FromRoute] int id, Product product)
    {
      return await _productService.UpdateProduct(id, product);
    }

    // DELETE product method:
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<List<Product>>> Delete([FromRoute] int id)
    {
      return await _productService.DeleteProduct(id);
    }
  }
}
