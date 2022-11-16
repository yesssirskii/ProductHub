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
    public int productId { get; set; }
    public string? name { get; set; }  
    public int price { get; set; }
    public string? country { get; set; }
    public ProductType? productType { get; set; }
  }
}
