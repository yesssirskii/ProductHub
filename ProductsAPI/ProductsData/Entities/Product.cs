using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData.Entities
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }
    public string? Name { get; set; }  
    public int Price { get; set; }
    public string? Country { get; set; }
    public ProductType? ProductType { get; set; }
  }
}
