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
    public string? name { get; set; }
    public int price { get; set; }
    public string? country { get; set; }
  }
}
