using ProductsData.Entities;

namespace ProductsData.Models
{
  public class CreateProductDTO
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Country { get; set; }
    public string? Type { get; set; }
    public ProductType? ProductType { get; set; }

  }
}
