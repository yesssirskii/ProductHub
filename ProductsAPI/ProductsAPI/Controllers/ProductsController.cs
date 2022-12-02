using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;
using ProductsData.Models;

namespace ProductsAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
      _productService = productService;
    }

    // This is the controller. It consists of API endpoints which are one-liners calling methods from the service.

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_productService.GetProducts());
    }

    [HttpPost]
    public IActionResult Create(CreateProductDTO createProductDto)
    {
      return Ok(_productService.CreateProduct(createProductDto));
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, UpdateProductDTO updateProductDto)
    {
      return Ok(_productService.UpdateProduct(id, updateProductDto));
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      return Ok(_productService.DeleteProduct(id));
    }
  }
}
