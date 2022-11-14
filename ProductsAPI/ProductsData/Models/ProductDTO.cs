using ProductsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData.Models
{
  public class ProductDTO
  {
    public int ProductId { get; set; }  
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Country { get; set; }
  }
}
