using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ProductsAPI.Repositories;
using ProductsAPI.Services;
using ProductsData.Entities;
using System.Security.Permissions;

namespace ProductsAPI.Controllers
{
  public class ProductsController : Controller
  {
    public ProductService _productService;

    // Injecting the DbContext and the product repository into the controller:
    public ProductsController(ProductDbContext context, ProductService productService) //constructor
    {
      _productService = productService;
    }
  }
}
