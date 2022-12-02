using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductTypeController : Controller
  {
    private readonly ProductService _productService;

    public ProductTypeController(ProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProductTypes()
    {
      return Ok(_productService.GetProductTypes());
    }

  }
}
