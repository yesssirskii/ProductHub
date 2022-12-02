using System.ComponentModel.DataAnnotations;

namespace ProductsData.Entities
{
  public class ProductType
  {
    [Key]
    public int Id { get; set; }
    public string? Type { get; set; }
  }
}
