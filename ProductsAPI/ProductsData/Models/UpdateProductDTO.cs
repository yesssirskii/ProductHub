using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData.Models
{
  public class UpdateProductDTO
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Country { get; set; }
  }
}
