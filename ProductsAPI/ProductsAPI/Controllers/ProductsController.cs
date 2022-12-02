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
    public IActionResult Get()
    {
      return Ok(_productService.GetProducts());
    }

    // POST product method:
    [HttpPost]
    public IActionResult Create(CreateProductDTO createProductDto)
    {
      return Ok(_productService.CreateProduct(createProductDto));
    }

    // PUT product method:
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, UpdateProductDTO updateProductDto)
    {
      return Ok(_productService.UpdateProduct(id, updateProductDto));
    }

    // DELETE product method:
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      return Ok(_productService.DeleteProduct(id));
    }
  }
}
