using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData.Entities
{
  public class ProductType
  {
    [Key]
    public int id { get; set; }
    public string? type { get; set; }
  }
}
